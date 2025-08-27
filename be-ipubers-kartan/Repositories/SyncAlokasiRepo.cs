using be_ipubers_kartan.Dtos;
using be_ipubers_kartan.Interface;
using be_ipubers_kartan.Models;
using be_ipubers_kartan.Models.Rekan;
using be_ipubers_kartan.ModelsCustom.ViewsModelCustom;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Polly;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace be_ipubers_kartan.Repositories
{
    public class SyncAlokasiRepo : ISyncAlokasiService
    {
        private readonly RMSContext _context;
        private readonly IMemoryCache _memoryCache;
        private readonly RekanContext _rekanContext;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public SyncAlokasiRepo ( RMSContext rMSContext, IMemoryCache memoryCache, RekanContext rekan, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _context = rMSContext;
            _memoryCache = memoryCache;
            _rekanContext = rekan;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        private async Task<Tuple<string, bool>> Auth()
        {
            var input = new
            {
                username = _configuration.GetSection("Kementan")["Username"],
                password = _configuration.GetSection("Kementan")["Password"]
            };

            var payload = JsonSerializer.Serialize(input);
            var requestAt = DateTime.Now;
            try
            {

                var httpClient = _httpClientFactory.CreateClient("Kementan");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
                var endpoint = _configuration.GetSection("Kementan")["Endpoints:auth"];


                var response = await httpClient.PostAsync(endpoint, httpContent);
                var responseAt = DateTime.Now;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseObj = JsonSerializer.Deserialize<AuthAlokasiResponseDto>(responseContent);
                    return Tuple.Create<string, bool>(responseObj.Data.AccessToken, true);
                }
                var responseString = await response.Content.ReadAsStringAsync();
                return Tuple.Create<string, bool>($"{responseString}", false);
            }
            catch (Exception e)
            {
                return Tuple.Create<string, bool>($"{e.Message}", false);
            }
        }
        private async Task<string> GetToken()
        {
            var (tokenString, statusToken) = await _memoryCache.GetOrCreateAsync(
                        "token-alokasi",
                        async entry =>
                        {
                            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(14));
                            return await Auth();
                        });

            if (statusToken)
            {
                return tokenString;
            }
            else
            {
                _memoryCache.Remove("token-alokasi");
                return await GetToken();
            }

        }
        public async Task<AlokasiResponse> GetAlokasi(AlokasiRequesDto request, string idRetailer, string token, CancellationToken cancellationToken = default)
        {
            try
            {
                int cek = _context.JsonAlokasis.Where(x => x.IdRetailer == idRetailer && x.Catatan == "alokasi").Count();

                if (cek > 0)
                {
                    var queryDummy = await _context.JsonAlokasis.FirstOrDefaultAsync(x => x.Catatan == "alokasi" && x.IdRetailer == idRetailer);
                    var responseObj = JsonSerializer.Deserialize<AlokasiResponse>(queryDummy.Response);
                    var msproduk = await _context.Produks.Select(x => new { x.KodeProduk, x.Gambar, x.Het }).ToListAsync(cancellationToken);

                    var listProdukBelumSync = await _context.PenjualanProdukRetailers
                            .Include(x => x.IdPenjualanNavigation)
                            .ThenInclude(x => x.IdPetaniNavigation)
                            .Include(x => x.IdProdukRetailerNavigation)
                            .Where(x => x.IdPenjualanNavigation.IdRetailer == idRetailer)
                            .Where(x => x.IdPenjualanNavigation.SyncAlokasiStatus == 2 || x.IdPenjualanNavigation.SyncAlokasiStatus == null)
                            .Where(x => x.IdPenjualanNavigation.TanggalNota.Year.Equals(DateTime.Now.Year))
                            .GroupBy(x => new
                            {
                                x.IdProdukRetailerNavigation.KodeProduk,
                                x.IdPenjualanNavigation.IdPetaniNavigation.Nik,
                                x.IdPenjualanNavigation.PoktanId,
                                x.IdPenjualanNavigation.KomoditiId
                            })
                            .Select(x => new
                            {
                                x.Key.KodeProduk,
                                x.Key.Nik,
                                x.Key.PoktanId,
                                x.Key.KomoditiId,
                                Total = (int)x.Sum(y => y.Qty)
                            }).ToListAsync(cancellationToken);

                    var kiosPilotingBri = "";
                    List<string> listnikkt = new List<string>();

                    var listNikKt = await _memoryCache.GetOrCreateAsync(
                        $"list-kt-{idRetailer}",
                        async entry =>
                        {
                            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
                            return await _rekanContext
                                .Rdkkpetanis
                                .AsNoTracking()
                                .Include(x => x.IdRdkkNavigation)
                                .Include(x => x.IdPetaniNavigation)
                                .Where(x =>  x.Status == 1 && x.IdRdkkNavigation.IdRetailer.Equals(idRetailer))
                                .Select(x => x.IdPetaniNavigation.Nik)
                                .Distinct()
                                .ToListAsync();
                        });

                    if (listNikKt.Count > 0)
                    {
                        kiosPilotingBri = idRetailer;
                        responseObj.data.petani = responseObj.data.petani
                            .GroupJoin(
                                listNikKt,
                                p => p.nik,
                                f => f,
                                (petani, petaniKartan) => new
                                {
                                    petani,
                                    petaniKartan
                                }
                            )
                            .SelectMany(
                                x => x.petaniKartan.DefaultIfEmpty(),
                                (petani, petaniKartan) => new
                                {
                                    petani,
                                    petaniKartan
                                }
                            )
                            .Select(x => new PetaniResponse
                            {
                                nik = x.petani.petani.nik,
                                idDokumentasiPoktan = x.petani.petani.idDokumentasiPoktan,
                                idKomoditas = x.petani.petani.idKomoditas,
                                idPetani = x.petani.petani.idPetani,
                                idRdkkPetani = x.petani.petani.idRdkkPetani,
                                //dev
                                isPetaniKartan = 1,
                                kelompokTani = x.petani.petani.kelompokTani,
                                kodeDesa = x.petani.petani.kodeDesa,
                                komoditas = x.petani.petani.komoditas,
                                luasTanam = x.petani.petani.luasTanam,
                                namaDesa = x.petani.petani.namaDesa,
                                namaPetani = x.petani.petani.namaPetani,
                                noHp = x.petani.petani.noHp,
                                pin = x.petani.petani.pin,
                                poktanId = x.petani.petani.poktanId,
                                tipeTransaksi = x.petani.petani.tipeTransaksi,
                                produk = x.petani.petani.produk
                            }).ToList();
                    }
                    //}
                    
                    responseObj.data.petani = responseObj.data.petani.Where(x => x.nik.Contains(request.keyword) || x.namaPetani.Contains(request.keyword) || x.kelompokTani.Contains(request.keyword)).ToList();

                    foreach (var item in responseObj.data.petani)
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        if (item.isPetaniKartan != null)
                        {
                            if (item.isPetaniKartan == 1)
                            {
                                item.namaDesa = item.namaDesa + " |";
                            }
                        }
                        foreach (var dtitem in item.produk)
                        {
                            dtitem.gambarProduk = msproduk.Where(b => b.KodeProduk == dtitem.kodeProduk).Select(a => a.Gambar).FirstOrDefault();
                            dtitem.hargaProduk = (int)msproduk.Where(b => b.KodeProduk == dtitem.kodeProduk).Select(a => a.Het).FirstOrDefault();
                            dtitem.totalKg = dtitem.totalKg - (listProdukBelumSync.FirstOrDefault(x => x.KodeProduk == dtitem.kodeProduk && x.Nik == item.nik && x.PoktanId.ToString() == item.poktanId && x.KomoditiId == dtitem.idKomoditas)?.Total ?? 0);
                            dtitem.totalSalur = dtitem.totalSalur + (listProdukBelumSync.FirstOrDefault(x => x.KodeProduk == dtitem.kodeProduk && x.Nik == item.nik && x.PoktanId.ToString() == item.poktanId && x.KomoditiId == dtitem.idKomoditas)?.Total ?? 0);

                            //if (!string.IsNullOrEmpty(kiosPilotingBri))
                            //{
                            //    if (item.isPetaniKartan != null)
                            //    {
                            //        if (item.isPetaniKartan == 1)
                            //        {
                            //            var listKodeProdukNonOrganik = new List<string>
                            //            {
                            //                "UN46","NPKP","NPKFK"
                            //            };
                            //            if (listKodeProdukNonOrganik.Contains(dtitem.kodeProduk))
                            //            {
                            //                dtitem.totalSalur = 0;
                            //                dtitem.totalKg = 0;
                            //                dtitem.totalAlokasi = 0;
                            //            }
                            //        }
                            //    }
                            //}
                        }
                    }

                    return responseObj;
                }
                else
                {
                    var queryDummy = await _context.JsonAlokasis.FirstOrDefaultAsync(x => x.Catatan == "alokasi" && x.IdRetailer == "RT0000054646");
                    var responseObj = JsonSerializer.Deserialize<AlokasiResponse>(queryDummy.Response);
                    var msproduk = await _context.Produks.Select(x => new { x.KodeProduk, x.Gambar, x.Het }).ToListAsync();

                    var listProdukBelumSync = await _context.PenjualanProdukRetailers
                            .Include(x => x.IdPenjualanNavigation)
                            .ThenInclude(x => x.IdPetaniNavigation)
                            .Include(x => x.IdProdukRetailerNavigation)
                            .Where(x => x.IdPenjualanNavigation.IdRetailer == idRetailer)
                            .Where(x => x.IdPenjualanNavigation.SyncAlokasiStatus == 2 || x.IdPenjualanNavigation.SyncAlokasiStatus == null)
                            .Where(x => x.IdPenjualanNavigation.TanggalNota.Year.Equals(DateTime.Now.Year))
                            .GroupBy(x => new
                            {
                                x.IdProdukRetailerNavigation.KodeProduk,
                                x.IdPenjualanNavigation.IdPetaniNavigation.Nik,
                                x.IdPenjualanNavigation.PoktanId,
                                x.IdPenjualanNavigation.KomoditiId
                            })
                            .Select(x => new
                            {
                                x.Key.KodeProduk,
                                x.Key.Nik,
                                x.Key.PoktanId,
                                x.Key.KomoditiId,
                                Total = (int)x.Sum(y => y.Qty)
                            }).ToListAsync();

                    var kiosPilotingBri = "";
                    List<string> listnikkt = new List<string>();

                    var listNikKt = await _memoryCache.GetOrCreateAsync(
                        $"list-kt-{idRetailer}",
                        async entry =>
                        {
                            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
                            return await _rekanContext
                                .Rdkkpetanis
                                .AsNoTracking()
                                .Include(x => x.IdRdkkNavigation)
                                .Include(x => x.IdPetaniNavigation)
                                .Where(x => x.IdRdkkNavigation.Tahun == 2024 && x.Status == 1 && x.IdRdkkNavigation.IdRetailer.Equals(idRetailer))
                                .Select(x => x.IdPetaniNavigation.Nik)
                                .Distinct()
                                .ToListAsync();
                        });

                    if (listNikKt.Count > 0)
                    {
                        kiosPilotingBri = idRetailer;
                        responseObj.data.petani = responseObj.data.petani
                            .GroupJoin(
                                listNikKt,
                                p => p.nik,
                                f => f,
                                (petani, petaniKartan) => new
                                {
                                    petani,
                                    petaniKartan
                                }
                            )
                            .SelectMany(
                                x => x.petaniKartan.DefaultIfEmpty(),
                                (petani, petaniKartan) => new
                                {
                                    petani,
                                    petaniKartan
                                }
                            )
                            .Select(x => new PetaniResponse
                            {
                                nik = x.petani.petani.nik,
                                idDokumentasiPoktan = x.petani.petani.idDokumentasiPoktan,
                                idKomoditas = x.petani.petani.idKomoditas,
                                idPetani = x.petani.petani.idPetani,
                                idRdkkPetani = x.petani.petani.idRdkkPetani,
                                isPetaniKartan = (x.petaniKartan != null ? 1 : 0),
                                kelompokTani = x.petani.petani.kelompokTani,
                                kodeDesa = x.petani.petani.kodeDesa,
                                komoditas = x.petani.petani.komoditas,
                                luasTanam = x.petani.petani.luasTanam,
                                namaDesa = x.petani.petani.namaDesa,
                                namaPetani = x.petani.petani.namaPetani,
                                noHp = x.petani.petani.noHp,
                                pin = x.petani.petani.pin,
                                poktanId = x.petani.petani.poktanId,
                                tipeTransaksi = x.petani.petani.tipeTransaksi,
                                produk = x.petani.petani.produk
                            }).ToList();
                    }
                    //}

                    responseObj.data.petani = responseObj.data.petani.Where(x => x.nik.Contains(request.keyword) || x.namaPetani.Contains(request.keyword) || x.kelompokTani.Contains(request.keyword)).ToList();

                    foreach (var item in responseObj.data.petani)
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        if (item.isPetaniKartan != null)
                        {
                            if (item.isPetaniKartan == 1)
                            {
                                item.namaDesa = item.namaDesa + " |";
                            }
                        }
                        foreach (var dtitem in item.produk)
                        {
                            dtitem.gambarProduk = msproduk.Where(b => b.KodeProduk == dtitem.kodeProduk).Select(a => a.Gambar).FirstOrDefault();
                            dtitem.hargaProduk = (int)msproduk.Where(b => b.KodeProduk == dtitem.kodeProduk).Select(a => a.Het).FirstOrDefault();
                            dtitem.totalKg = dtitem.totalKg - (listProdukBelumSync.FirstOrDefault(x => x.KodeProduk == dtitem.kodeProduk && x.Nik == item.nik && x.PoktanId.ToString() == item.poktanId && x.KomoditiId == dtitem.idKomoditas)?.Total ?? 0);
                            dtitem.totalSalur = dtitem.totalSalur + (listProdukBelumSync.FirstOrDefault(x => x.KodeProduk == dtitem.kodeProduk && x.Nik == item.nik && x.PoktanId.ToString() == item.poktanId && x.KomoditiId == dtitem.idKomoditas)?.Total ?? 0);

                            if (!string.IsNullOrEmpty(kiosPilotingBri))
                            {
                                if (item.isPetaniKartan != null)
                                {
                                    if (item.isPetaniKartan == 1)
                                    {
                                        var listKodeProdukNonOrganik = new List<string>
                                        {
                                            "UN46","NPKP","NPKFK"
                                        };
                                        if (listKodeProdukNonOrganik.Contains(dtitem.kodeProduk))
                                        {
                                            dtitem.totalSalur = 0;
                                            dtitem.totalKg = 0;
                                            dtitem.totalAlokasi = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    return responseObj;
                }

                var pollyContext = new Context("Retry 204");
                var policy = Policy
                    .Handle<HttpRequestException>(ex => ex.StatusCode == HttpStatusCode.NoContent)
                    .WaitAndRetryAsync(
                        5,
                        _ => TimeSpan.FromMilliseconds(500),
                        (result, timespan, retryNo, context) =>
                        {
                            Console.WriteLine($"{context.OperationKey}: Retry number {retryNo} within " +
                                $"{timespan.TotalMilliseconds}ms. Original status code: {result.Message}");
                        }
                    );

                token = await GetToken();

                var requestAt = DateTime.Now;
                var httpClient = _httpClientFactory.CreateClient("Kementan");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var endpoint = _configuration.GetSection("Kementan")["BaseURL"] + _configuration.GetSection("Kementan")["Endpoints:farmers"];
                //var endpoint = "https://alokasi.rms-pi.com/farmers";

                var url = $"{endpoint}?idRetailer=" + idRetailer + "&pageNo=" + request.pageNo + "&pageSize=" + request.pageSize + "&keyword=" + request.keyword.ToUpper();

                var response = await policy.ExecuteAsync(async ctx =>
                {
                    var response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    return response;
                }, pollyContext);
                var responseAt = DateTime.Now;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseObj = JsonSerializer.Deserialize<AlokasiResponse>(responseContent);

                    var msproduk = await _context.Produks.Select(x => new { x.KodeProduk, x.Gambar, x.Het }).ToListAsync();

                    var listProdukBelumSync = await _context.PenjualanProdukRetailers
                            .Include(x => x.IdPenjualanNavigation)
                            .ThenInclude(x => x.IdPetaniNavigation)
                            .Include(x => x.IdProdukRetailerNavigation)
                            .Where(x => x.IdPenjualanNavigation.IdRetailer == idRetailer)
                            .Where(x => x.IdPenjualanNavigation.SyncAlokasiStatus == 2 || x.IdPenjualanNavigation.SyncAlokasiStatus == null)
                            .Where(x => x.IdPenjualanNavigation.TanggalNota.Year.Equals(DateTime.Now.Year))
                            .GroupBy(x => new
                            {
                                x.IdProdukRetailerNavigation.KodeProduk,
                                x.IdPenjualanNavigation.IdPetaniNavigation.Nik,
                                x.IdPenjualanNavigation.PoktanId,
                                x.IdPenjualanNavigation.KomoditiId
                            })
                            .Select(x => new
                            {
                                x.Key.KodeProduk,
                                x.Key.Nik,
                                x.Key.PoktanId,
                                x.Key.KomoditiId,
                                Total = (int)x.Sum(y => y.Qty)
                            }).ToListAsync();

                    var kiosPilotingBri = "";
                    List<string> listnikkt = new List<string>();

                    var listNikKt = await _memoryCache.GetOrCreateAsync(
                        $"list-kt-{idRetailer}",
                        async entry =>
                        {
                            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
                            return await _rekanContext
                                .Rdkkpetanis
                                .AsNoTracking()
                                .Include(x => x.IdRdkkNavigation)
                                .Include(x => x.IdPetaniNavigation)
                                .Where(x => x.IdRdkkNavigation.Tahun == 2024 && x.Status == 1 && x.IdRdkkNavigation.IdRetailer.Equals(idRetailer))
                                .Select(x => x.IdPetaniNavigation.Nik)
                                .Distinct()
                                .ToListAsync();
                        });

                    if (listNikKt.Count > 0)
                    {
                        kiosPilotingBri = idRetailer;
                        responseObj.data.petani = responseObj.data.petani
                            .GroupJoin(
                                listNikKt,
                                p => p.nik,
                                f => f,
                                (petani, petaniKartan) => new
                                {
                                    petani,
                                    petaniKartan
                                }
                            )
                            .SelectMany(
                                x => x.petaniKartan.DefaultIfEmpty(),
                                (petani, petaniKartan) => new
                                {
                                    petani,
                                    petaniKartan
                                }
                            )
                            .Select(x => new PetaniResponse
                            {
                                nik = x.petani.petani.nik,
                                idDokumentasiPoktan = x.petani.petani.idDokumentasiPoktan,
                                idKomoditas = x.petani.petani.idKomoditas,
                                idPetani = x.petani.petani.idPetani,
                                idRdkkPetani = x.petani.petani.idRdkkPetani,
                                isPetaniKartan = (x.petaniKartan != null ? 1 : 0),
                                kelompokTani = x.petani.petani.kelompokTani,
                                kodeDesa = x.petani.petani.kodeDesa,
                                komoditas = x.petani.petani.komoditas,
                                luasTanam = x.petani.petani.luasTanam,
                                namaDesa = x.petani.petani.namaDesa,
                                namaPetani = x.petani.petani.namaPetani,
                                noHp = x.petani.petani.noHp,
                                pin = x.petani.petani.pin,
                                poktanId = x.petani.petani.poktanId,
                                tipeTransaksi = x.petani.petani.tipeTransaksi,
                                produk = x.petani.petani.produk
                            }).ToList();
                    }
                    //}

                    foreach (var item in responseObj.data.petani)
                    {
                        if (item.isPetaniKartan != null)
                        {
                            if (item.isPetaniKartan == 1)
                            {
                                item.namaDesa = item.namaDesa + " |";
                            }
                        }
                        foreach (var dtitem in item.produk)
                        {
                            dtitem.gambarProduk = msproduk.Where(b => b.KodeProduk == dtitem.kodeProduk).Select(a => a.Gambar).FirstOrDefault();
                            dtitem.hargaProduk = (int)msproduk.Where(b => b.KodeProduk == dtitem.kodeProduk).Select(a => a.Het).FirstOrDefault();
                            dtitem.totalKg = dtitem.totalKg - (listProdukBelumSync.FirstOrDefault(x => x.KodeProduk == dtitem.kodeProduk && x.Nik == item.nik && x.PoktanId.ToString() == item.poktanId && x.KomoditiId == dtitem.idKomoditas)?.Total ?? 0);
                            dtitem.totalSalur = dtitem.totalSalur + (listProdukBelumSync.FirstOrDefault(x => x.KodeProduk == dtitem.kodeProduk && x.Nik == item.nik && x.PoktanId.ToString() == item.poktanId && x.KomoditiId == dtitem.idKomoditas)?.Total ?? 0);

                            if (!string.IsNullOrEmpty(kiosPilotingBri))
                            {
                                if (item.isPetaniKartan != null)
                                {
                                    if (item.isPetaniKartan == 1)
                                    {
                                        var listKodeProdukNonOrganik = new List<string>
                                        {
                                            "UN46","NPKP","NPKFK"
                                        };
                                        if (listKodeProdukNonOrganik.Contains(dtitem.kodeProduk))
                                        {
                                            dtitem.totalSalur = 0;
                                            dtitem.totalKg = 0;
                                            dtitem.totalAlokasi = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    return responseObj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<ValidasiAlokasiResponse> CekAlokasi(AlokasiRequesDto request, string idRetailer, string token, Models.Penjualan penjualan, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                int idKomoditasPenjualan = penjualan.KomoditiId.HasValue ? penjualan.KomoditiId.Value : 0;
                string poktandId = penjualan.PoktanId.ToString();
                var alokasi = await GetAlokasi(request, idRetailer, token, cancellationToken);

                var petaniResponse = alokasi.data.petani.FirstOrDefault(x => x.idKomoditas == idKomoditasPenjualan && x.poktanId == poktandId);
                List<ProdukResponse> product = petaniResponse?.produk?.ToList() ?? new List<ProdukResponse>();

                if (petaniResponse == null)
                {
                    return null; 
                }

                ProdukValidasiResponse response = new ProdukValidasiResponse();

                response.Urea = Convert.ToInt32(penjualan.PenjualanProdukRetailers.FirstOrDefault(x => x.IdProdukRetailerNavigation.KodeProduk == "UN46")?.Qty ?? 0);
                response.UreaAlokasi = product.Where(a => a.kodeProduk == "UN46").Select(a => a.totalKg).FirstOrDefault();
                response.UreaSelisih = response.UreaAlokasi - response.Urea;

                response.Npk = Convert.ToInt32(penjualan.PenjualanProdukRetailers.FirstOrDefault(x => x.IdProdukRetailerNavigation.NamaProduk == "NPKP")?.Qty ?? 0);
                response.NpkAlokasi = product.Where(a => a.kodeProduk == "NPKP").Select(a => a.totalKg).FirstOrDefault();
                response.NpkSelisih = response.NpkAlokasi - response.Npk;

                response.NpkFormula = Convert.ToInt32(penjualan.PenjualanProdukRetailers.FirstOrDefault(x => x.IdProdukRetailerNavigation.KodeProduk == "NPKFK")?.Qty ?? 0);
                response.NpkFormulaAlokasi = product.Where(a => a.kodeProduk == "NPKFK").Select(a => a.totalKg).FirstOrDefault();
                response.NpkFormulaSelisih = response.NpkFormulaAlokasi - response.NpkFormula;

                response.Za = Convert.ToInt32(penjualan.PenjualanProdukRetailers.FirstOrDefault(x => x.IdProdukRetailerNavigation.KodeProduk == "ASZA")?.Qty ?? 0);
                response.ZaAlokasi = product.Where(a => a.kodeProduk == "ASZA").Select(a => a.totalKg).FirstOrDefault();
                response.ZaSelisih = response.ZaAlokasi - response.Za;

                response.Sp36 = Convert.ToInt32(penjualan.PenjualanProdukRetailers.FirstOrDefault(x => x.IdProdukRetailerNavigation.KodeProduk == "SFSP36")?.Qty ?? 0);
                response.Sp36Alokasi = product.Where(a => a.kodeProduk == "SFSP36").Select(a => a.totalKg).FirstOrDefault();
                response.Sp36Selisih = response.Sp36Alokasi - response.Sp36;

                response.Organic = Convert.ToInt32(penjualan.PenjualanProdukRetailers.FirstOrDefault(x => x.IdProdukRetailerNavigation.KodeProduk == "ORGR")?.Qty ?? 0);
                response.OrganicAlokasi = product.Where(a => a.kodeProduk == "ORGR").Select(a => a.totalKg).FirstOrDefault();
                response.OrganicSelisih = response.OrganicAlokasi - response.Organic;

                response.Poc = Convert.ToInt32(penjualan.PenjualanProdukRetailers.FirstOrDefault(x => x.IdProdukRetailerNavigation.KodeProduk == "ORCR")?.Qty ?? 0);
                response.PocAlokasi = product.Where(a => a.kodeProduk == "Poc").Select(a => a.totalKg).FirstOrDefault();
                response.PocSelisih = response.PocAlokasi - response.Poc;

                response.KomoditasId = petaniResponse.idKomoditas;
                response.Komoditas = petaniResponse.komoditas;

                response.NIK = petaniResponse.nik;

                ValidasiAlokasiResponse responseSelisih = new ValidasiAlokasiResponse();
                responseSelisih.product = response;
                responseSelisih.IsPetaniKartan = petaniResponse.isPetaniKartan;

                var isUrea = penjualan.PenjualanProdukRetailers.FirstOrDefault(x => x.IdProdukRetailerNavigation.KodeProduk == "UN46");
                var isNpk = penjualan.PenjualanProdukRetailers.FirstOrDefault(x => x.IdProdukRetailerNavigation.KodeProduk == "NPKP");
                var isNpkfk = penjualan.PenjualanProdukRetailers.FirstOrDefault(x => x.IdProdukRetailerNavigation.KodeProduk == "NPKFK");
                var isAzsa = penjualan.PenjualanProdukRetailers.FirstOrDefault(x => x.IdProdukRetailerNavigation.KodeProduk == "ASZA");
                var isSp36 = penjualan.PenjualanProdukRetailers.FirstOrDefault(x => x.IdProdukRetailerNavigation.KodeProduk == "SFSP36");
                var isOrcr = penjualan.PenjualanProdukRetailers.FirstOrDefault(x => x.IdProdukRetailerNavigation.KodeProduk == "ORCR");
                var isOrgr = penjualan.PenjualanProdukRetailers.FirstOrDefault(x => x.IdProdukRetailerNavigation.KodeProduk == "ORGR");

                if (isUrea != null)
                {
                    if (response.UreaSelisih < 0)
                    {
                        responseSelisih.Selisih = true;
                        responseSelisih.SelisihDeskripsi = responseSelisih.SelisihDeskripsi + " Urea Tidak Mencukupi";
                    }
                }

                if (isNpk != null)
                {
                    if (response.NpkSelisih < 0)
                    {
                        responseSelisih.Selisih = true;
                        responseSelisih.SelisihDeskripsi = "Npk Tidak Mencukupi";
                    }
                }

                if (isNpkfk != null)
                {
                    if (response.NpkFormulaSelisih < 0)
                    {
                        responseSelisih.Selisih = true;
                        responseSelisih.SelisihDeskripsi = responseSelisih.SelisihDeskripsi + " Npk Formula Tidak Mencukupi";
                    }
                }

                if (isAzsa != null)
                {
                    if (response.ZaSelisih < 0)
                    {
                        responseSelisih.Selisih = true;
                        responseSelisih.SelisihDeskripsi = responseSelisih.SelisihDeskripsi + " Za Tidak Mencukupi";
                    }
                }

                if (isSp36 != null)
                {
                    if (response.Sp36Selisih < 0)
                    {
                        responseSelisih.Selisih = true;
                        responseSelisih.SelisihDeskripsi = responseSelisih.SelisihDeskripsi + " SP36 Tidak Mencukupi";
                    }
                }

                if (isOrcr != null)
                {
                    if (response.PocSelisih < 0)
                    {
                        responseSelisih.Selisih = true;
                        responseSelisih.SelisihDeskripsi = responseSelisih.SelisihDeskripsi + " Poc Tidak Mencukupi";
                    }
                }

                if (isOrgr != null)
                {
                    if (response.OrganicSelisih < 0)
                    {
                        responseSelisih.Selisih = true;
                        responseSelisih.SelisihDeskripsi = responseSelisih.SelisihDeskripsi + " Organic Tidak Mencukupi";
                    }
                }

                return responseSelisih;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
