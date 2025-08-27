using be_ipubers_kartan.Constants;
using be_ipubers_kartan.Dtos;
using be_ipubers_kartan.Exceptions;
using be_ipubers_kartan.Helpers;
using be_ipubers_kartan.Interface;
using be_ipubers_kartan.Models;
using be_ipubers_kartan.Models.Rekan;
using be_ipubers_kartan.Repositories;
using be_ipubers_kartan.Services;
using be_ipubers_kartan.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace be_ipubers_kartan.Controllers
{

    [ApiController]
    [Route("")]
    public class TransaksiController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly RekanContext _rekanContext;
        private readonly RMSContext _context;
        private readonly ITransaksiKartanService _transaksiKartanService;
        private readonly ITransactionService _transactionService;
        private readonly IProdukRetailerService _produkRetailerService;
        private readonly ISyncRekanService _sycnRekanService;
        private readonly IJenisKomoditasRepo _jenisKomoditasRepo;
        private readonly string? _token;
        private readonly string _connectionString;
        private readonly string _rekanConn;

        public TransaksiController(RekanContext rekanContext, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IMemoryCache memoryCache, ITransaksiKartanService transaksiKartanService, RMSContext rmsContext, IProdukRetailerService produkRetailerService, ISyncRekanService sycnRekanService, ITransactionService transactionService,
            IJenisKomoditasRepo jenisKomoditasRepo)
        {
            _transactionService = transactionService;
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
            _rekanConn = configuration.GetConnectionString("RekanConnection") ?? throw new InvalidOperationException("Connection string 'RekanConnection' is not configured.");
            _rekanContext = rekanContext;
            _httpContextAccessor = httpContextAccessor;
            _memoryCache = memoryCache;
            _transaksiKartanService = transaksiKartanService;
            _context = rmsContext;
            _produkRetailerService = produkRetailerService;
            _sycnRekanService = sycnRekanService;
            _jenisKomoditasRepo = jenisKomoditasRepo;

            _token = null;
            if (_httpContextAccessor.HttpContext?.Request != null)
            {
                _token = _httpContextAccessor.HttpContext.Request.Headers[Constanta.AUTHORIZATION];
            }
        }

        [HttpPost]
        [Route("/transaksi-kartan")]
        [Authorize(Roles = "KEMENTAN")]
        public async Task<IActionResult> CreateTransaksiKartan([FromBody] CreateTransaksiKartanDto body)
        {
            ModelResultDtos modelResult = new();

            try
            {
                CreateTransaksiKartanDtosValidator validator = new(_jenisKomoditasRepo);

                var validationResult = await validator.ValidateAsync(body);
                if (!validationResult.IsValid)
                {
                    ModelResultDtos errorValidation = ValidationHelper.HandleValidationErrors(validationResult, HeadingMessages.TransaksiKartan.Failed);
                    throw new BusinessRuleViolationException(errorValidation.StatusDesc, errorValidation.StatusCode, errorValidation.StatusDescHeading);
                }

                // Cancellation token to limit execution time (max 10 seconds)
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
                CancellationToken cancellationToken = cts.Token;

                CreateTransaksiKartanDtos model = new CreateTransaksiKartanDtos
                {
                    ReferenceNumber = body.ReferenceNumber,
                    TanggalTransaksi = body.TanggalTransaksi,
                    NIK = body.NIK,
                    Nama = body.Nama,
                    KodeKios = body.KodeKios,
                    IdKomoditas = body.IdKomoditas,
                    KodeProduk = body.KodeProduk,
                    MID = body.MID,
                    transaksi = body.transaksi
                };

                cancellationToken.ThrowIfCancellationRequested();

                #region Validasi Model

                //Validate RefNum is Exist
                var listTransaksi = await _transaksiKartanService.GetListTransaksiByRefnumAndRetailerId(model.KodeKios, model.ReferenceNumber);
                if (listTransaksi.Count() != 0)
                {
                    if (!string.IsNullOrEmpty(listTransaksi.First().NoNotaBatal))
                    {
                        throw new BusinessRuleViolationException(
                            $"Transaksi dengan referal number {model.ReferenceNumber} sudah ada di iPubers dan sudah dibatalkan",
                            ResponseCodeMapping.ErrorDuplicateReferenceNumber,
                            HeadingMessages.TransaksiKartan.Failed
                        );
                    }

                    return Ok(new ModelResultDtos
                    {
                        StatusCode = ResponseCodeMapping.SuccessDuplicate,
                        StatusDesc = $"Transaksi dengan referal number {model.ReferenceNumber} sudah ada di iPubers",
                        StatusDescHeading = HeadingMessages.TransaksiKartan.Success,
                        Data = listTransaksi.Select(t => t.NoNota).ToList()
                    });
                }

                // Get username from JWT token
                var request = Request.GetHeaderValueByKey(Constanta.AUTHORIZATION);
                var username = CustomHttpRequest.GetValueFromJWT(ClaimTypes.Name, request.Replace("Bearer ", ""));

                // Validasi retailer piloting
                var isPiloting = _rekanContext.RetailerRoles
                    .Where(x => x.IdRetailer == model.KodeKios)
                    .Select(x => x.IsPiloting)
                    .FirstOrDefault();

                if (isPiloting == false)
                {
                    throw new BusinessRuleViolationException(
                        "⁠Terjadi kesalahan pada status aktivasi Kios di iPubers",
                        ResponseCodeMapping.ErrorRetailerActivationStatus,
                        HeadingMessages.TransaksiKartan.Failed
                    );
                }

                // Validasi Retailer Pegawai
                string? prefix = await _rekanContext.RetailerPegawais
                    .Where(w => w.Username == model.KodeKios)
                    .Select(s => s.NoPrefix)
                    .FirstOrDefaultAsync();

                if (string.IsNullOrEmpty(prefix))
                {
                    throw new BusinessRuleViolationException(
                        "Pegawai Kios tidak ditemukan",
                        ResponseCodeMapping.ErrorRetailerEmployeeNotFound,
                        HeadingMessages.TransaksiKartan.Failed
                    );
                }

                // Ambil last nomor transaksi sebelumnya
                var lastNumber = await _transaksiKartanService.LastNumber(prefix, model.KodeKios);
                string lastNumberTransaction = lastNumber.FirstOrDefault(w => w.JenisTransaksi == "S")?.LastNumber ?? "00000";
                string currentRunningNumber = lastNumberTransaction;

                string kelompokTani = model.transaksi.FirstOrDefault().namaPoktan ?? model.transaksi.FirstOrDefault().poktanId.ToString();

                // Get data petani and insert Petani NIK if not Exists
                var petaniIpubers = await _transactionService.GetDataPetaniIpubers(username, new Models.Petani()
                {
                    Nik = model.NIK,
                    NamaPetani = model.Nama,
                    KelompokTani = kelompokTani
                });

                var petaniRekan = await _transactionService.GetDatapetaniRekan(username, new Models.Rekan.Petani()
                {
                    Nik = model.NIK,
                    NamaPetani = model.Nama,
                    KelompokTani = kelompokTani
                });

                // Get both data product retailer
                var produkRetailerIpubers = await _produkRetailerService.GetProdukRetailer(model.KodeKios, model.KodeProduk, "ipubers");
                var produkRetailerRekan = await _produkRetailerService.GetProdukRetailer(model.KodeKios, model.KodeProduk, "rekan");

                var hargaJual = await _transaksiKartanService.GetHargaJual(model.KodeProduk);

                #endregion

                #region Mapping Model

                var penjualanList = new List<TransaksiKartanPenjualan>();
                DateTime tanggalNota = DateTime.Parse(model.TanggalTransaksi);

                // Validasi Stock di Rekan
                var cekNotaBelumSync = await _sycnRekanService.SyncToRekanByIdRetailer(model.KodeKios, _token, cancellationToken);
                if (cekNotaBelumSync.SyncBerhasil == false)
                {
                    throw new BusinessRuleViolationException(
                        cekNotaBelumSync.Message,
                        ResponseCodeMapping.ErrorNotaSyncFailed,
                        cekNotaBelumSync.Header
                    );
                }

                //cek stok kecamatan
                var listKecamatan = new Dictionary<string, string>();
                foreach (var kodeDesa in model.transaksi.Select(x => x.KodeDesa).Distinct())
                {
                    var kecamatanId = await GetIdKecamatan(kodeDesa);
                    if (!string.IsNullOrEmpty(kecamatanId))
                    {
                        listKecamatan[kodeDesa] = kecamatanId;
                    }
                }

                var neededStokPerKecamatan = model.transaksi
                    .GroupBy(x => listKecamatan[x.KodeDesa])
                    .ToDictionary(
                        g => g.Key,
                        g => g.Sum(x => x.Qty)
                    );

                var listStok = await _transactionService.GetStokRekanByKodeProdukKodeKios(
                    model.KodeProduk,
                    model.KodeKios,
                    neededStokPerKecamatan.Keys.ToList()
                );

                foreach (var NeededStock in neededStokPerKecamatan)
                {
                    var idKecamatan = NeededStock.Key;
                    var qtyDibutuhkan = NeededStock.Value;

                    var stokKecamatan = listStok.FirstOrDefault(x => x.IdKecamatan == idKecamatan);
                    if (stokKecamatan == null || stokKecamatan.Stok < qtyDibutuhkan)
                    {
                        throw new BusinessRuleViolationException(
                            $"Transaksi Gagal karena Stok tidak mencukupi di kecamatan {stokKecamatan.NamaKecamatan}",
                            ResponseCodeMapping.ErrorStock,
                            HeadingMessages.TransaksiKartan.Failed
                        );
                    }
                }

                // Set current stok before loop
                var currentStokPerKecamatan = listStok.ToDictionary(
                    x => x.IdKecamatan,
                    x => x.Stok
                );

                // Loop transaksi
                foreach (var transaksi in model.transaksi)
                {
                    TransaksiKartanPenjualan penjualanModel = new();

                    cancellationToken.ThrowIfCancellationRequested();

                    string idKecamatan = await GetIdKecamatan(transaksi.KodeDesa);

                    // Generate nomor nota
                    string newNumber = StringHelper.RunningAlphanumeric(currentRunningNumber);
                    string lastsix = currentRunningNumber.Substring(Math.Max(0, currentRunningNumber.Length - 6));
                    string lastIncPrefix = lastsix.Substring(0, 1);
                    string backslash = "\\";
                    string noNota = $"S{prefix}{backslash}{lastIncPrefix}{newNumber}";

                    // Siapkan entitas Penjualan
                    penjualanModel.Ipubers = new Models.Penjualan
                    {
                        NoNota = noNota,
                        IdRetailer = model.KodeKios,
                        IdPetani = petaniIpubers.Id,
                        KodePelanggan = model.MID,
                        Nama = model.Nama,
                        NoHp = model.NIK,
                        TanggalNota = tanggalNota,
                        TanggalJatuhTempo = tanggalNota,
                        FotoKtppembeli = model.ReferenceNumber,
                        FotoKtppembeliLokasi = null,
                        FotoKtppembeliWaktu = DateTime.Now,
                        FotoKtppemilik = model.ReferenceNumber,
                        FotoKtppemilikLokasi = model.ReferenceNumber,
                        FotoKtppemilikWaktu = DateTime.Now,
                        JenisPenjualan = "1",
                        Status = "2",
                        NoReferensi = model.ReferenceNumber,
                        Catatan = "Transaksi Kartan BRI",
                        CreatedAt = DateTime.Now,
                        CreatedBy = username,
                        UpdatedAt = null,
                        UpdatedBy = null,
                        PoktanId = transaksi.poktanId,
                        KodeDesa = transaksi.KodeDesa,
                        Source = 27,
                        KomoditiId = model.IdKomoditas,
                        NamaPoktan = transaksi.namaPoktan
                    };

                    penjualanModel.Rekan = clonePenjualan(penjualanModel.Ipubers);
                    penjualanModel.Rekan.IdPetani = petaniRekan.Id;

                    // Setup product retailer (ipubers)
                    penjualanModel.Ipubers.PenjualanProdukRetailers.Add(new Models.PenjualanProdukRetailer
                    {
                        IdProdukRetailer = produkRetailerIpubers.Id,
                        HargaJual = hargaJual,
                        Qty = transaksi.Qty,
                    });

                    // Setup product retailer (rekan)
                    penjualanModel.Rekan.PenjualanProdukRetailers.Add(new Models.PenjualanProdukRetailer
                    {
                        IdProdukRetailer = produkRetailerRekan.Id,
                        HargaJual = hargaJual,
                        Qty = transaksi.Qty,
                    });

                    penjualanModel.Rekan.PenjualanProdukRetailers.FirstOrDefault().IdProdukRetailerNavigation = new Models.ProdukRetailer
                    {
                        Id = produkRetailerRekan.Id,
                        KodeProduk = produkRetailerRekan.KodeProduk,
                        NamaProduk = produkRetailerRekan.NamaProduk,
                        Stok = produkRetailerRekan.Stok,
                    };

                    var pembayaran = new Models.Pembayaran
                    {
                        Jumlah = transaksi.Qty * hargaJual,
                    };

                    // Setup pembayaran
                    penjualanModel.Ipubers.Pembayarans.Add(pembayaran);
                    penjualanModel.Rekan.Pembayarans.Add(pembayaran);

                    // Validasi data nota sudah ada
                    var existingData = await getDataPenjualan(penjualanModel.Ipubers);
                    if (existingData != null)
                    {
                        throw new BusinessRuleViolationException(
                            "Data nota sudah ada",
                            ResponseCodeMapping.ErrorNotaAlreadyExists,
                            HeadingMessages.TransaksiKartan.Failed
                        );
                    }

                    // Setup product retailer stock (only for rekan)
                    var penjualanProdukRetailer = penjualanModel.Rekan.PenjualanProdukRetailers.LastOrDefault();

                    double currentStok = currentStokPerKecamatan[idKecamatan];
                    double qty = penjualanProdukRetailer.Qty;
                    double stokAkhir = currentStok - qty;

                    var produk = penjualanProdukRetailer?.IdProdukRetailerNavigation;
                    if (produk != null)
                    {
                        produk.Stok = stokAkhir;
                    }

                    //initialize produkRetailerStock
                    penjualanProdukRetailer?.IdProdukRetailerNavigation.ProdukRetailerStoks.Add(new Models.ProdukRetailerStok
                    {
                        StokAwal = currentStok,
                        JumlahStok = penjualanProdukRetailer.Qty,
                        StokAkhir = stokAkhir,
                        TglTransaksi = penjualanModel.Rekan.TanggalNota
                    });

                    currentStokPerKecamatan[idKecamatan] = stokAkhir;

                    penjualanList.Add(penjualanModel);
                    currentRunningNumber = newNumber;
                }

                #endregion

                double totalStok = currentStokPerKecamatan.Sum(x => x.Value);

                #region Insert Data
                using var connIpubers = new SqlConnection(_connectionString);
                using var connRekan = new SqlConnection(_rekanConn);
                await connIpubers.OpenAsync();
                await connRekan.OpenAsync();

                using var transIpubers = connIpubers.BeginTransaction();
                using var transRekan = connRekan.BeginTransaction();

                try
                {
                    foreach (var penjualan in penjualanList)
                    {
                        // Insert to Ipubers database
                        cancellationToken.ThrowIfCancellationRequested();
                        await _transactionService.InsertIntoIpubers(penjualan.Ipubers, connIpubers, transIpubers);

                        //Insert to Rekan Database
                        cancellationToken.ThrowIfCancellationRequested();
                        await _transactionService.InsertIntoRekan(penjualan.Rekan, connRekan, transRekan);
                    }

                    var dtoProdukRetailer = new UpdateProdukRetailerStokIpubersDtos
                    {
                        Id = produkRetailerIpubers.Id,
                        Stok = totalStok
                    };

                    await _produkRetailerService.UpdateStokAsync(dtoProdukRetailer, (SqlTransaction)transIpubers);

                    await transIpubers.CommitAsync();
                    await transRekan.CommitAsync();

                    return Ok(new ModelResultDtos
                    {
                        StatusCode = ResponseCodeMapping.Success,
                        StatusDesc = "Transaksi berhasil dilakukan",
                        StatusDescHeading = HeadingMessages.TransaksiKartan.Success,
                        Data = penjualanList.Select(p => p.Ipubers.NoNota).ToList(),
                    });
                }
                catch (OperationCanceledException)
                {
                    throw new BusinessRuleViolationException(HeadingMessages.Default.Timeout, ResponseCodeMapping.ErrorTimeout, HeadingMessages.TransaksiKartan.Failed);
                }
                catch (Exception ex)
                {
                    await transIpubers.RollbackAsync();
                    await transRekan.RollbackAsync();

                    throw new BusinessRuleViolationException(
                        ex.Message,
                        StatusCodes.Status500InternalServerError,
                        HeadingMessages.TransaksiKartan.Failed
                    );
                }

                #endregion
            }
            catch (OperationCanceledException)
            {
                throw new BusinessRuleViolationException(HeadingMessages.Default.Timeout, ResponseCodeMapping.ErrorTimeout, HeadingMessages.TransaksiKartan.Failed);
            }
            catch (BusinessRuleViolationException)
            {
                throw;
            }
            catch (SqlException sqlEx)
            {
                throw new BusinessRuleViolationException(sqlEx.Message, StatusCodes.Status500InternalServerError, HeadingMessages.TransaksiKartan.Failed);
            }
            catch (ArgumentNullException argExc)
            {
                throw new BusinessRuleViolationException(argExc.Message, StatusCodes.Status500InternalServerError, HeadingMessages.TransaksiKartan.Failed);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleViolationException(
                    ex.Message,
                    StatusCodes.Status500InternalServerError,
                    HeadingMessages.TransaksiKartan.Failed
                );
            }
        }

        [HttpPost]
        [Route("/transaksi-kartan/reversal")]
        [Authorize(Roles = "KEMENTAN")]
        public async Task<IActionResult> CreateTransaksiKartanReversal([FromBody] CreateTransaksiReversalDto body)
        {
            ModelResultDtos response = new();

            try
            {
                CreateTransaksiReversalDtoValidator validator = new();

                var validationResult = await validator.ValidateAsync(body);
                if (!validationResult.IsValid)
                {
                    ModelResultDtos errorValidation = ValidationHelper.HandleValidationErrors(validationResult, HeadingMessages.TransaksiKartanReversal.Failed);
                    throw new BusinessRuleViolationException(errorValidation.StatusDesc, errorValidation.StatusCode, errorValidation.StatusDescHeading);
                }

                // Cancellation token to limit execution time (default 10 seconds)
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
                CancellationToken cancellationToken = cts.Token;

                // Get username from JWT token
                var request = Request.GetHeaderValueByKey(Constanta.AUTHORIZATION);
                var username = CustomHttpRequest.GetValueFromJWT(ClaimTypes.Name, request.Replace("Bearer ", ""));

                #region Validasi Model

                // Check list transaksi by refnum
                var listTransaksi = await _transaksiKartanService.GetListTransaksiByRefnum(body.Refnum);
                if (listTransaksi.Count() == 0)
                {
                    throw new BusinessRuleViolationException(
                        "Transaksi Tidak Ditemukan",
                        ResponseCodeMapping.ErrorNotaNotFound,
                        HeadingMessages.TransaksiKartanReversal.Failed
                    );
                }

                // Cek duplikat nota reversal
                List<string> listNoNota = listTransaksi.Select(t => t.NoNota).ToList();
                var listNotaReversal = await _transaksiKartanService.GetListNoNotaByMultipleRefnum(listNoNota);

                if (listNotaReversal.Any())
                {
                    response.StatusCode = ResponseCodeMapping.SuccessReversalDuplicate;
                    response.StatusDesc = $"Transaksi reversal dengan referal number {body.Refnum} sudah ada di iPubers";
                    response.StatusDescHeading = HeadingMessages.TransaksiKartanReversal.Success;
                    response.Data = listNotaReversal.Select(p => p.NoNota).ToList();

                    return Ok(response);
                }

                #endregion

                #region Mapping List Transaksi Reversal

                // Validasi Stock di Rekan
                string IdRetailer = listTransaksi.FirstOrDefault().IdRetailer;

                var cekNotaBelumSync = await _sycnRekanService.SyncToRekanByIdRetailer(IdRetailer, _token, cancellationToken);
                if (cekNotaBelumSync.SyncBerhasil == false)
                {
                    throw new BusinessRuleViolationException(
                        cekNotaBelumSync.Message,
                        ResponseCodeMapping.ErrorNotaSyncFailed,
                        cekNotaBelumSync.Header
                    );
                }

                var listKecamatan = new Dictionary<string, string>();
                foreach (var kodeDesa in listTransaksi.Select(x => x.KodeDesa).Distinct())
                {
                    var kecamatanId = await GetIdKecamatan(kodeDesa);
                    if (!string.IsNullOrEmpty(kecamatanId))
                    {
                        listKecamatan[kodeDesa] = kecamatanId;
                    }
                }

                var transaksiPertama = listTransaksi.FirstOrDefault();
                string KodeProduk = await _transactionService.GetKodeProdukFromIdPenjualan(transaksiPertama.Id.ToString());
                
                var listStok = await _transactionService.GetStokRekanByKodeProdukKodeKios(
                    KodeProduk,
                    IdRetailer,
                    listKecamatan.Values.ToList()
                );

                // Set current stok before loop
                var currentStokPerKecamatan = listStok.ToDictionary(
                    x => x.IdKecamatan,
                    x => x.Stok
                );

                var penjualanList = new List<TransaksiKartanPenjualan>();

                foreach (var transaksi in listTransaksi)
                {
                    TransaksiKartanPenjualan penjualanModel = new();

                    // Get transaksi Rekan with the same nota
                    Models.Rekan.Penjualan transaksiRekan = await _transaksiKartanService.GetRekanTransaksiByNota(transaksi.NoNota);

                    string newNota = $"R{transaksi.NoNota[1..]}";

                    // Set model Penjualan Reversal
                    penjualanModel.Ipubers = new Models.Penjualan
                    {
                        NoNota = newNota,
                        IdRetailer = transaksi.IdRetailer,
                        IdPetani = transaksi.IdPetani,
                        KodePelanggan = transaksi.KodePelanggan,
                        Nama = transaksi.Nama,
                        NoHp = transaksi.NoHp,
                        TanggalNota = transaksi.TanggalNota,
                        TanggalJatuhTempo = transaksi.TanggalJatuhTempo,
                        FotoKtppembeli = transaksi.FotoKtppembeli,
                        FotoKtppembeliLokasi = transaksi.FotoKtppembeliLokasi,
                        FotoKtppembeliWaktu = transaksi.FotoKtppembeliWaktu,
                        FotoKtppemilik = transaksi.FotoKtppemilik,
                        FotoKtppemilikLokasi = transaksi.FotoKtppemilikLokasi,
                        FotoKtppemilikWaktu = transaksi.FotoKtppemilikWaktu,
                        JenisPenjualan = transaksi.JenisPenjualan,
                        Status = "3",
                        NoReferensi = transaksi.NoNota,
                        Catatan = body.Alasan,
                        CreatedAt = DateTime.Now,
                        CreatedBy = username,
                        UpdatedAt = null,
                        UpdatedBy = null,
                        PoktanId = transaksi.PoktanId,
                        KodeDesa = transaksi.KodeDesa,
                        Source = transaksi.Source,
                        KomoditiId = transaksi.KomoditiId,
                        TanggalNotaWib = DateTime.Now,
                        CreatedAtRegion = DateTime.Now,
                        NamaPoktan = transaksi.NamaPoktan
                    };

                    penjualanModel.Rekan = clonePenjualan(penjualanModel.Ipubers);
                    penjualanModel.Rekan.IdPetani = transaksiRekan.IdPetani;

                    // Get data penjualan produk retailer
                    var penjualanProdukRetailerIpubers = await _transaksiKartanService.GetPenjualanProdukRetailerIpubers(transaksi.Id, transaksi.IdRetailer);
                    var penjualanProdukRetailerRekan = await _transaksiKartanService.GetPenjualanProdukRetailerRekan(transaksiRekan.Id, transaksiRekan.IdRetailer);

                    if (penjualanProdukRetailerIpubers == null || penjualanProdukRetailerRekan == null)
                    {
                        throw new BusinessRuleViolationException(
                            "Penjualan Produk Retailer tidak ditemukan",
                            ResponseCodeMapping.ErrorRetailerProductNotFound,
                            HeadingMessages.TransaksiKartanReversal.Failed
                        );
                    }

                    // Setup product retailer (ipubers)
                    penjualanModel.Ipubers.PenjualanProdukRetailers.Add(new Models.PenjualanProdukRetailer
                    {
                        IdProdukRetailer = penjualanProdukRetailerIpubers.IdProdukRetailer,
                        HargaJual = penjualanProdukRetailerIpubers.HargaJual,
                        Qty = penjualanProdukRetailerIpubers.Qty,
                        IdProdukRetailerNavigation = penjualanProdukRetailerIpubers.IdProdukRetailerNavigation
                    });

                    // Setup product retailer (rekan)
                    var produkRetailerRekan = penjualanProdukRetailerRekan.IdProdukRetailerNavigation;
                    penjualanModel.Rekan.PenjualanProdukRetailers.Add(new Models.PenjualanProdukRetailer
                    {
                        IdProdukRetailer = penjualanProdukRetailerRekan.IdProdukRetailer,
                        HargaJual = penjualanProdukRetailerRekan.HargaJual,
                        Qty = penjualanProdukRetailerRekan.Qty,
                        IdProdukRetailerNavigation = new Models.ProdukRetailer()
                        {
                            Id = produkRetailerRekan.Id,
                            KodeProduk = produkRetailerRekan.KodeProduk,
                            NamaProduk = produkRetailerRekan.NamaProduk,
                            Stok = produkRetailerRekan.Stok,
                        }
                    });

                    // Setup pembayaran (ipubers)
                    penjualanModel.Ipubers.Pembayarans.Add(new Models.Pembayaran
                    {
                        Catatan = body.Alasan,
                        JenisPembayaran = "1",
                        Jumlah = Convert.ToDecimal(penjualanProdukRetailerIpubers.Qty) * penjualanProdukRetailerIpubers.HargaJual,
                        TanggalPembayaran = transaksi.TanggalNota
                    });

                    // Setup pembayaran (rekan)
                    penjualanModel.Rekan.Pembayarans.Add(new Models.Pembayaran
                    {
                        Catatan = body.Alasan,
                        JenisPembayaran = "1",
                        Jumlah = Convert.ToDecimal(penjualanProdukRetailerRekan.Qty) * penjualanProdukRetailerRekan.HargaJual,
                        TanggalPembayaran = transaksiRekan.TanggalNota
                    });

                    // Setup product retailer stock (only for rekan)
                    var penjualanProdukRetailer = penjualanModel.Rekan.PenjualanProdukRetailers.LastOrDefault();
                    string idKecamatan = await GetIdKecamatan(transaksi.KodeDesa);

                    double currentStok = currentStokPerKecamatan[idKecamatan];
                    double qty = penjualanProdukRetailer.Qty;
                    double stokAkhir = currentStok - qty;

                    var produk = penjualanProdukRetailer?.IdProdukRetailerNavigation;
                    if (produk != null)
                    {
                        produk.Stok = stokAkhir;
                    }

                    //initialize produkRetailerStock
                    penjualanProdukRetailer.IdProdukRetailerNavigation.ProdukRetailerStoks.Add(new Models.ProdukRetailerStok
                    {
                        StokAwal = currentStok,
                        JumlahStok = penjualanProdukRetailer.Qty,
                        StokAkhir = stokAkhir,
                        TglTransaksi = transaksiRekan.TanggalNota
                    });

                    currentStokPerKecamatan[idKecamatan] = stokAkhir;

                    penjualanList.Add(penjualanModel);
                }

                #endregion

                double totalStok = currentStokPerKecamatan.Sum(x => x.Value);

                #region Insert Data

                using var connIpubers = new SqlConnection(_connectionString);
                using var connRekan = new SqlConnection(_rekanConn);

                await connIpubers.OpenAsync();
                await connRekan.OpenAsync();

                using var transIpubers = connIpubers.BeginTransaction();
                using var transRekan = connRekan.BeginTransaction();

                try
                {
                    foreach (var penjualan in penjualanList)
                    {
                        // Insert to Ipubers database
                        cancellationToken.ThrowIfCancellationRequested();
                        await _transactionService.InsertIntoIpubers(penjualan.Ipubers, connIpubers, transIpubers);

                        //Insert to Rekan Database
                        cancellationToken.ThrowIfCancellationRequested();
                        await _transactionService.InsertIntoRekan(penjualan.Rekan, connRekan, transRekan);
                    }

                    var dtoProdukRetailer = new UpdateProdukRetailerStokIpubersDtos
                    {
                        Id = penjualanList.First().Ipubers.PenjualanProdukRetailers.FirstOrDefault().IdProdukRetailer,
                        Stok = totalStok
                    };

                    await _produkRetailerService.UpdateStokAsync(dtoProdukRetailer, (SqlTransaction)transIpubers);

                    await transIpubers.CommitAsync();
                    await transRekan.CommitAsync();

                    response.StatusCode = ResponseCodeMapping.Success;
                    response.StatusDesc = "Transaksi berhasil dibatalkan";
                    response.StatusDescHeading = "Proses Reversal Berhasil";
                    response.Data = penjualanList.Select(p => p.Ipubers.NoNota).ToList();

                    return Ok(response);
                }
                catch (OperationCanceledException)
                {
                    throw new BusinessRuleViolationException(HeadingMessages.Default.Timeout, ResponseCodeMapping.ErrorTimeout, HeadingMessages.TransaksiKartanReversal.Failed);
                }
                catch (Exception ex)
                {
                    await transIpubers.RollbackAsync();
                    await transRekan.RollbackAsync();

                    throw new BusinessRuleViolationException(
                        ex.Message,
                        StatusCodes.Status500InternalServerError,
                        HeadingMessages.TransaksiKartanReversal.Failed
                    );
                }
                
                #endregion
            }
            catch (OperationCanceledException)
            {
                throw new BusinessRuleViolationException(HeadingMessages.Default.Timeout, ResponseCodeMapping.ErrorTimeout, HeadingMessages.TransaksiKartanReversal.Failed);
            }
            catch (BusinessRuleViolationException)
            {
                throw;
            }
            catch (SqlException sqlEx)
            {
                throw new BusinessRuleViolationException(sqlEx.Message, StatusCodes.Status500InternalServerError, HeadingMessages.TransaksiKartanReversal.Failed);
            }
            catch (ArgumentNullException argExc)
            {
                throw new BusinessRuleViolationException(argExc.Message, StatusCodes.Status500InternalServerError, HeadingMessages.TransaksiKartanReversal.Failed);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleViolationException(
                    ex.Message,
                    StatusCodes.Status500InternalServerError,
                    HeadingMessages.TransaksiKartanReversal.Failed
                );
            }
        }

        private async Task<string> GetIdKecamatan(string kodeDesa)
        {
            var idKecamatan = kodeDesa?.Substring(0, 6);
            string key = $"list-kodedesa";

            var listKodeDesa = await _memoryCache.GetOrCreateAsync(
                key,
                async entry =>
                {
                    entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                    return await _rekanContext.Areas
                    .Join(_rekanContext.MappingAreas,
                    p => p.DistrictCode,
                    f => f.DistrictCode,
                    (areas, mapping) => new
                    {
                        areas,
                        mapping
                    }).Where(x => x.mapping.Tahun == DateTime.Now.Year)
                    .Select(x => new
                    {
                        x.areas.SubDistrictCode,
                        x.areas.DistrictCode,
                        x.mapping.IdKecamatanRekan
                    }).ToListAsync();
                });

            var area = listKodeDesa.Where(x => x.SubDistrictCode.Equals(kodeDesa)).Select(x => x.IdKecamatanRekan).FirstOrDefault();
            if (area != null)
            {
                idKecamatan = area;
            }

            return idKecamatan;
        }

        private async Task<Models.Penjualan> getDataPenjualan(Models.Penjualan penjualan)
        {
            var data = await _context.Penjualans
                .Where(p => p.NoNota == penjualan.NoNota && p.TanggalNota == penjualan.TanggalNota && p.Status == penjualan.Status)
                .FirstOrDefaultAsync();

            return data;
        }

        private Models.Penjualan clonePenjualan(Models.Penjualan penjualan)
        {
            return new Models.Penjualan()
            {
                NoNota = penjualan.NoNota,
                IdRetailer = penjualan.IdRetailer,
                IdPetani = penjualan.IdPetani,
                KodePelanggan = penjualan.KodePelanggan,
                Nama = penjualan.Nama,
                NoHp = penjualan.NoHp,
                TanggalNota = penjualan.TanggalNota,
                TanggalJatuhTempo = penjualan.TanggalJatuhTempo,

                FotoKtppembeli = penjualan.FotoKtppembeli,
                FotoKtppembeliLokasi = penjualan.FotoKtppembeliLokasi,
                FotoKtppembeliWaktu = penjualan.FotoKtppembeliWaktu,
                FotoKtppemilik = penjualan.FotoKtppemilik,
                FotoKtppemilikLokasi = penjualan.FotoKtppemilikLokasi,
                FotoKtppemilikWaktu = penjualan.FotoKtppemilikWaktu,

                JenisPenjualan = penjualan.JenisPenjualan,
                Status = penjualan.Status,
                NoReferensi = penjualan.NoReferensi,
                Catatan = penjualan.Catatan,

                CreatedAt = penjualan.CreatedAt,
                CreatedBy = penjualan.CreatedBy,
                UpdatedAt = penjualan.UpdatedAt,
                UpdatedBy = penjualan.UpdatedBy,

                PoktanId = penjualan.PoktanId,
                KodeDesa = penjualan.KodeDesa,
                Source = penjualan.Source,
                KomoditiId = penjualan.KomoditiId,
                NamaPoktan = penjualan.NamaPoktan
            };
        }
    }
}
