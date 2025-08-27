using be_ipubers_kartan.Dtos;
using be_ipubers_kartan.Interface;
using be_ipubers_kartan.Models;
using be_ipubers_kartan.ModelsCustom.ViewsModelCustom;
using be_ipubers_kartan.ViewsModels;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Trace;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace be_ipubers_kartan.Repositories
{
    public class SycnRekanRepo : ISyncRekanService
    {
        private readonly RMSContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly PenjualanRekanViewModel _penjualanRekanViewModel;
        private readonly Tracer _tracer;
        public SycnRekanRepo(RMSContext rMSContext, PenjualanRekanViewModel penjualanRekanViewModel, IConfiguration configuration, IHttpClientFactory httpClientFactory, TracerProvider provider)
        {
            _context = rMSContext ?? throw new ArgumentNullException(nameof(rMSContext));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _penjualanRekanViewModel = penjualanRekanViewModel ?? throw new ArgumentNullException(nameof(penjualanRekanViewModel));
            _tracer = provider.GetTracer("sync-rekan-repo-tracer");
        }
        private async Task LoginRekan()
        {
            try
            {
                var input = new
                {
                    UserName = "PT0000000000",
                    Password = "Pupuk123",
                    DeviceId = "postman",
                    grant_type = "Password",
                    AppVersion = "1.2.19",
                    AndroidVersion = "Android X",
                    LatLong = "100|-90",
                    DeviceModel = "Imin POS"
                };
                var payload = JsonSerializer.Serialize(input);

                var httpClient = _httpClientFactory.CreateClient("Rekan");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
                var endpoint = _configuration.GetSection("Rekan")["Endpoints:Login"];
                var response = await httpClient.PostAsync(endpoint, httpContent);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions() { WriteIndented = true };
                    options.Converters.Add(new CustomDateTimeConverter("yyyy-MM-dd HH:mm:ss"));

                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseObj = JsonSerializer.Deserialize<LoginResponseDto>(responseContent, options);
                    var tokenDb = await _context.SyncTokens.FirstOrDefaultAsync();

                    if (tokenDb != null)
                    {
                        tokenDb.Token = responseObj.Token;
                        tokenDb.ExpiredDate = responseObj.ValidTo;
                        _context.SyncTokens.Update(tokenDb);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        private async Task<string> GetTokenRekan()
        {
            var tokenDb = await _context.SyncTokens.FirstOrDefaultAsync();
            if (tokenDb.ExpiredDate <= DateTime.Now)
            {
                await LoginRekan();
                return await GetTokenRekan();
            }

            return tokenDb.Token;
        }
        public async Task<bool> SyncToRekan(VMCPenjualanCreateDto model, string token)
        {

            var dataPenjualan = _context.Penjualans.FirstOrDefault(x => x.NoNota == model.Penjualan.NoNota);
            model.Penjualan.KodePelanggan = dataPenjualan.KodePelanggan;
            model.Penjualan.LogInfo = null;
            model.Pembayaran.LogInfo = null;
            model.ProdukRetailerStok.ForEach(x => x.LogInfo = null);
            try
            {
                token = await GetTokenRekan();
                using var span = _tracer.StartActiveSpan("sync-to-rekan-http-call", SpanKind.Client);

                var payload = JsonSerializer.Serialize(model);

                var httpClient = _httpClientFactory.CreateClient("Rekan");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                //httpClient.DefaultRequestHeaders.Add("x-api-version", "4.0");

                var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
                //var endpoint = _configuration.GetSection("Rekan")["Endpoints:Penjualan"];
                var baseUrl = _configuration.GetSection("Rekan")["BaseURL"];
                var endpoint = _configuration.GetSection("Rekan")["Endpoints:Penjualan"];
                var url = new Uri(new Uri(baseUrl), endpoint);
                var response = await httpClient.PostAsync(url, httpContent);
                
                span.SetAttribute("http.status_code", (int)response.StatusCode);

                //var response = await httpClient.PostAsync(endpoint, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseObj = JsonSerializer.Deserialize<ModelsCustom.ModelResult>(responseContent);
                    if (responseObj.StatusCode == 200)
                    {
                        dataPenjualan.SyncRekanAt = DateTime.Now;
                        dataPenjualan.SyncRekanMessage = responseObj.StatusDesc;
                        dataPenjualan.SyncRekanStatus = 1;

                        _context.Penjualans.Attach(dataPenjualan);
                        var entry = _context.Entry(dataPenjualan);
                        entry.Property(e => e.SyncRekanAt).IsModified = true;
                        entry.Property(e => e.SyncRekanMessage).IsModified = true;
                        entry.Property(e => e.SyncRekanStatus).IsModified = true;

                        await _context.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        dataPenjualan.SyncRekanAt = DateTime.Now;
                        dataPenjualan.SyncRekanMessage = responseObj.StatusDesc;
                        dataPenjualan.SyncRekanStatus = 2;
                        _context.Penjualans.Update(dataPenjualan);
                        await _context.SaveChangesAsync();
                        return false;
                    }
                }
                else
                {
                    dataPenjualan.SyncRekanAt = DateTime.Now;
                    dataPenjualan.SyncRekanMessage = await response.Content.ReadAsStringAsync();
                    dataPenjualan.SyncRekanStatus = 2;
                    _context.Penjualans.Update(dataPenjualan);
                    await _context.SaveChangesAsync();
                    return false;
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                if (ex.InnerException != null)
                {
                    error = ex.InnerException.Message;
                }
                dataPenjualan.SyncRekanAt = DateTime.Now;
                dataPenjualan.SyncRekanMessage = error;
                dataPenjualan.SyncRekanStatus = 2;
                _context.Penjualans.Update(dataPenjualan);
                await _context.SaveChangesAsync();

                return false;
            }
        }

        public async Task<ResponseSyncRekanAllDto> SyncToRekanByIdRetailer(string idretailer, string token, CancellationToken cancellationToken = default)
        {
            try
            {
                var NotaBelumSync = await _context.Penjualans
                    .Where(x => x.SyncRekanStatus == 2 || x.SyncRekanStatus == null)
                    .Where(x => x.IdRetailer == idretailer)
                    .Select(x => x.NoNota).ToListAsync(cancellationToken);

                foreach (var item in NotaBelumSync)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var modelSync = await _penjualanRekanViewModel.CreateModelPenjualanFromNota(item);
                    var cekstokcukup = await SyncToRekan(modelSync, token);
                    if (cekstokcukup == false)
                    {
                        return new ResponseSyncRekanAllDto
                        {
                            SyncBerhasil = false,
                            Header = "Opss.. Stok pupuk habis",
                            Message = "Transaksi Gagal"
                        };
                    }
                }
                return new ResponseSyncRekanAllDto
                {
                    SyncBerhasil = true,
                    Header = "-",
                    Message = "-"
                };
                throw new NotImplementedException();
            }
            catch
            {
                throw new("Gagal Sync to rekan");
            }
            
        }

        public async Task<ResponseCheckStokDto> CheckStok(Models.Penjualan model, string token, string idkecamatan, string kodeProduk, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                token = await GetTokenRekan();
                var produkIds = model.PenjualanProdukRetailers.Select(x => "produkId=" + x.IdProdukRetailer).ToList();

                var httpClient = _httpClientFactory.CreateClient("Rekan");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                httpClient.DefaultRequestHeaders.Add("x-api-version", "4.0");

                var baseUrl = _configuration.GetSection("Rekan")["BaseURL"];
                var endpoint = _configuration.GetSection("Rekan")["Endpoints:CheckStok"];

                var queryString = string.Join("&", produkIds);

                var url = $"{baseUrl}{endpoint}?{queryString}&kios={model.IdRetailer}&idKecamatan={idkecamatan}";
                var response = await httpClient.GetAsync(url, cancellationToken);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseObj = JsonSerializer.Deserialize<ModelResultCekStokDto>(responseContent);
                    if (responseObj.StatusCode == 200)
                    {
                        var listProdukBelumSync = await _context.PenjualanProdukRetailers
                            .Include(x => x.IdPenjualanNavigation)
                            .Include(x => x.IdProdukRetailerNavigation)
                            .Where(x => x.IdPenjualanNavigation.SyncRekanStatus == 2 || x.IdPenjualanNavigation.SyncRekanStatus == null)
                            .Where(x => x.IdPenjualanNavigation.IdRetailer == model.IdRetailer && x.IdPenjualanNavigation.KodeDesa.StartsWith(idkecamatan))
                            .GroupBy(x => new
                            {
                                x.IdProdukRetailerNavigation.KodeProduk
                            })
                            .Select(x => new
                            {
                                x.Key.KodeProduk,
                                Total = x.Sum(y => y.Qty)
                            }).ToListAsync();

                        var stokAkhir = responseObj.Data.Select(x => new StokProduk
                        {
                            Gambar = x.Gambar,
                            KodeKios = x.KodeKios,
                            KodeProduk = x.KodeProduk,
                            Produk = x.Produk,
                            Satuan = x.Satuan,
                            Stok = x.Stok - (listProdukBelumSync.FirstOrDefault(y => y.KodeProduk == x.KodeProduk)?.Total ?? 0)
                        }).ToList();
                        responseObj.Data = stokAkhir;

                        var stokCukupSemua = true;
                        var stokHabis = false;
                        var produkHabis = new List<string>();
                        var jumlahProdukDicari = model.PenjualanProdukRetailers.FirstOrDefault()?.Qty;

                        var produkDitemukan = responseObj.Data.FirstOrDefault(p => p.KodeProduk == kodeProduk);

                        if (produkDitemukan == null)
                        {
                            return new ResponseCheckStokDto
                            {
                                StokCukup = false,
                                Header = "Opss.. Produk tidak ditemukan",
                                Message = $"Maaf ya, transaksi nggak bisa lanjutkan karena produk dengan kode {kodeProduk} tidak ditemukan di sistem Rekan. Coba lakukan penebusan ke Distributor dulu ya"
                            };
                        }

                        var stokTersedia = produkDitemukan.Stok - (listProdukBelumSync.FirstOrDefault(y => y.KodeProduk == kodeProduk)?.Total ?? 0);

                        bool stokCukup = jumlahProdukDicari <= stokTersedia;
                        if (!stokCukup)
                        {
                            stokHabis = true;
                        }

                        produkDitemukan.Stok = stokTersedia;

                        if (stokHabis)
                        {
                            var kecamatan = await _context.MasterKecamatans.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(idkecamatan));
                            return new ResponseCheckStokDto
                            {
                                StokCukup = false,
                                Header = "Opss.. Stok pupuk habis",
                                Message = $"Maaf ya, transaksi nggak bisa lanjutkan karena stok Pupuk ({string.Join(",", produkHabis)}) Anda tidak mencukupi untuk transaksi ke Petani di kecamatan {kecamatan.Nama}. Coba lakukan penebusan ke Distributor dulu ya"
                            };
                        }
                        if (stokCukupSemua)
                        {
                            return new ResponseCheckStokDto
                            {
                                stockAwal = produkDitemukan.Stok,
                                StokCukup = true,
                                Header = "-",
                                Message = "-"
                            };
                        }
                        else
                        {
                            var kecamatan = await _context.MasterKecamatans.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(idkecamatan));
                            return new ResponseCheckStokDto
                            {
                                StokCukup = false,
                                Header = "Opss.. Stok pupuk tidak cukup",
                                Message = $"Maaf ya, transaksi nggak bisa lanjutkan karena stok Pupuk ({string.Join(",", produkHabis)}) Anda tidak mencukupi untuk transaksi ke Petani di kecamatan {kecamatan.Nama}. Coba lakukan penebusan ke Distributor dulu ya"
                            };
                        }

                    }
                    else if (responseObj.StatusCode == 204)
                    {
                        var kecamatan = await _context.MasterKecamatans.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(idkecamatan));
                        //var produkIdList = model.PenjualanProdukRetailer.Select(x => x.ProdukRetailer.KodeProduk).ToList();
                        var produkHabis = await _context.ProdukRetailers.AsNoTracking().Where(x => x.IdRetailer.Equals(model.IdRetailer)).ToListAsync();

                        return new ResponseCheckStokDto
                        {
                            StokCukup = false,
                            Header = "Opss.. Stok pupuk tidak cukup",
                            Message = $"Maaf ya, transaksi nggak bisa lanjutkan karena stok Pupuk ({string.Join(",", produkHabis)}) Anda tidak mencukupi untuk transaksi ke Petani di kecamatan {kecamatan.Nama}. Coba lakukan penebusan ke Distributor dulu ya"
                        };
                    }
                    else
                    {
                        var kecamatan = await _context.MasterKecamatans.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(idkecamatan));
                        //var produkIdList = model.PenjualanProdukRetailer.Select(x => x.ProdukRetailer.KodeProduk).ToList();
                        var produkHabis = await _context.ProdukRetailers.AsNoTracking().Where(x => x.IdRetailer.Equals(model.IdRetailer)).ToListAsync();

                        return new ResponseCheckStokDto
                        {
                            StokCukup = false,
                            Header = "Opss.. Stok pupuk tidak cukup",
                            Message = $"Maaf ya, transaksi nggak bisa lanjutkan karena stok Pupuk ({string.Join(",", produkHabis)}) Anda tidak mencukupi untuk transaksi ke Petani di kecamatan {kecamatan.Nama}. Coba lakukan penebusan ke Distributor dulu ya!"
                        };
                    }
                }

                return new ResponseCheckStokDto { StokCukup = false, Message = "Stok Tidak Mencukupi" };
            }
            catch (Exception ex)
            {
                return new ResponseCheckStokDto { StokCukup = false, Message = ex.Message };
            }
        }
    }

}

