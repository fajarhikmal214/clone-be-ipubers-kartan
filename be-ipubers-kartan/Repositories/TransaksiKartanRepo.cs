using System.Data;
using be_ipubers_kartan.Dtos;
using be_ipubers_kartan.Interface;
using be_ipubers_kartan.Models;
using be_ipubers_kartan.Models.Rekan;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Repositories
{
    public class TransaksiKartanRepo : ITransaksiKartanService
    {
        private readonly string _connectionString;
        private readonly string _rekanConn;
        private readonly RMSContext _context;
        private readonly RekanContext _rekanContext;
        private readonly PenjualanProdukRetailerRepo _penjualanProdukRetailerRepo;
        private readonly IPembayaran _pembayaranRepo;
        private readonly IConfiguration _config;
        private readonly IProdukRetailerService _produkRetailerService;
        private readonly IProdukRetailerStokRekanService _produkRetailerStokRekanService;
        private readonly IProdukRetailerStokKecamatanService _produkRetailerStokKecamatanService;

        public TransaksiKartanRepo(IConfiguration configuration, RMSContext rMSContext, PenjualanProdukRetailerRepo penjualanProdukRetailerRepo, IPembayaran pembayaran, IProdukRetailerService produkRetailerService, IProdukRetailerStokRekanService produkRetailerStokRekanService, IProdukRetailerStokKecamatanService produkRetailerStokKecamatanService, RekanContext rekanContext)
        {
            _context = rMSContext;
            _rekanContext = rekanContext;
            _config = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
            _rekanConn = configuration.GetConnectionString("RekanConnection") ?? throw new InvalidOperationException("Connection string 'RekanConnection' is not configured.");
            _penjualanProdukRetailerRepo = penjualanProdukRetailerRepo;
            _pembayaranRepo = pembayaran;
            _produkRetailerService = produkRetailerService;
            _produkRetailerStokRekanService = produkRetailerStokRekanService;
            _produkRetailerStokKecamatanService = produkRetailerStokKecamatanService;
        }

        public async Task<T> GetDataPetani<T>(string nik, string source = "ipubers")
        {
            string connectionString = source == "ipubers" ? _connectionString : _rekanConn;
            using var connection = new SqlConnection(connectionString);

            var sql = "SELECT * FROM Petani p WHERE p.NIK = @nik";
            var result = await connection.QueryFirstOrDefaultAsync<T>(sql, new { nik });

            if (result == null)
                throw new KeyNotFoundException($"Petani with Nik {nik} not found.");

            return result;
        }

        public async Task<Models.MasterKelompokTani> GetDataPoktanPetani(string IdPoktan)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM MasterKelompokTani WHERE Id = @IdPoktan";
            var result = await connection.QueryFirstOrDefaultAsync<Models.MasterKelompokTani>(sql, new { IdPoktan = IdPoktan });
            if (result == null)
            {
                throw new KeyNotFoundException($"PoktanPetani with IdPoktan {IdPoktan} not found.");
            }
            return result;
        }

        public async Task<IEnumerable<LastNumberDtos>> LastNumber(string prefix, string idRetailer, int startIndex = 2)
        {
            string query = @"select isnull(b.JenisTransaksi, a.Kode) JenisTransaksi,
								   isnull(NoPrefix,@prefix) NoPrefix,
								   isnull(LastNumber, '00000')      LastNumber
							from VMasterKode a
									 left join (select left(NoNota, 1)         JenisTransaksi,
													   substring(NoNota, @startIndex, 5) NoPrefix,
													   max(right(NoNota, 5))   LastNumber
												from Penjualan
												where idRetailer = @idRetailer and substring(NoNota, @startIndex, 5) = @prefix
												group by left(NoNota, 1),
														 substring(NoNota, @startIndex, 5)) b on a.Kode = b.JenisTransaksi
							where a.IdInduk = 12";

            List<LastNumberDtos> result = new List<LastNumberDtos>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var resultPenjualanLastNumber = await conn.QueryAsync<LastNumberDtos>(query, new { prefix, startIndex, idRetailer });
                var resultBatchLastNumber = await this.BatchLastNumberAsync(prefix, idRetailer);

                result.AddRange(resultPenjualanLastNumber);
                result.AddRange(resultBatchLastNumber);
            }

            return result;
        }

        public async Task<List<LastNumberDtos>> BatchLastNumberAsync(string prefix, string idRetailer)
        {
            var data = await _context.Penjualans
                        .Where(x => x.IdRetailer.Equals(idRetailer))
                        .Where(w => w.Source == 6 && w.BatchId.Substring(2, 5) == prefix)
                        .GroupBy(g => new LastNumberDtos
                        {
                            JenisTransaksi = g.BatchId.Substring(0, 2),
                            NoPrefix = g.BatchId.Substring(2, 5)
                        })
                        .Select(s => new LastNumberDtos
                        {
                            JenisTransaksi = s.Key.JenisTransaksi,
                            NoPrefix = s.Key.NoPrefix,
                            LastNumber = s.Max(m => m.BatchId.Substring(9, 3))
                        }).ToListAsync();
            if (data is null)
                return Enumerable.Empty<LastNumberDtos>().ToList();

            return data;
        }

        public async Task<decimal> GetHargaJual(string kodeProduk)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "SELECT ph.hargajual FROM ProdukHarga ph INNER JOIN Produk p ON ph.IdProduk = p.Id WHERE p.KodeProduk = @kodeProduk";
            var hargaJual = await connection.QueryFirstOrDefaultAsync<decimal>(sql, new { kodeProduk = kodeProduk });
            if (hargaJual == default)
                throw new KeyNotFoundException($"Produk with KodeProduk {kodeProduk} not found.");
            return hargaJual;
        }

        public async Task<List<TransaksiAndReversalDto>> GetListTransaksiByRefnumAndRetailerId(string idRetailer, string refnum)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = @"
                SELECT DISTINCT 
                    p.NoNota, p.NoReferensi, batal.NoNota AS NoNotaBatal
                FROM 
                    Penjualan p
                LEFT JOIN Penjualan batal ON p.NoNota = batal.NoReferensi
                WHERE 
                    p.NoReferensi = @RefNum
                    AND p.IdRetailer = @IdRetailer";

            var result = await connection.QueryAsync<TransaksiAndReversalDto>(query, new { IdRetailer = idRetailer, RefNum = refnum });
            return result.ToList();
        }

        public async Task<List<Models.Penjualan>> GetListTransaksiByRefnum(string refnum)
        {
            var listTransaksi = await _context.Penjualans
                .Where(p => p.NoReferensi == refnum)
                .ToListAsync();

            return listTransaksi;
        }

        public async Task<Models.Rekan.Penjualan> GetRekanTransaksiByNota(string noNota)
        {
            var transaksi = await _rekanContext.Penjualans
                .Where(p => p.NoNota == noNota)
                .FirstOrDefaultAsync();

            return transaksi;
        }

        public async Task<List<Models.Penjualan>> GetListNoNotaByMultipleRefnum(List<string> refnums)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = @"
                SELECT 
                    NoNota
                FROM Penjualan
                WHERE
                    NoReferensi IN @Refnums";


            var result = await connection.QueryAsync<Models.Penjualan>(query, new { Refnums = refnums });
            return result.AsList();
        }

        public async Task<Models.PenjualanProdukRetailer> GetPenjualanProdukRetailerIpubers(int id, string idRetailer)
        {
            var penjualanProdukRetailer = await _context.PenjualanProdukRetailers
                    .Where(ppr => ppr.IdPenjualan == id)
                    .Join(
                        _context.ProdukRetailers.Where(pr => pr.IdRetailer == idRetailer),
                        ppr => ppr.IdProdukRetailer,
                        pr => pr.Id,
                        (ppr, pr) => new Models.PenjualanProdukRetailer
                        {
                            HargaBeli = 0,
                            HargaJual = ppr.HargaJual,
                            Qty = ppr.Qty * -1,
                            IdProdukRetailer = pr.Id,
                            IdProdukRetailerNavigation = pr
                        })
                    .FirstOrDefaultAsync();

            return penjualanProdukRetailer;
        }

        public async Task<Models.Rekan.PenjualanProdukRetailer> GetPenjualanProdukRetailerRekan(int id, string idRetailer)
        {
            var penjualanProdukRetailer = await _rekanContext.PenjualanProdukRetailers
                    .Where(ppr => ppr.IdPenjualan == id)
                    .Join(
                        _rekanContext.ProdukRetailers.Where(pr => pr.IdRetailer == idRetailer),
                        ppr => ppr.IdProdukRetailer,
                        pr => pr.Id,
                        (ppr, pr) => new Models.Rekan.PenjualanProdukRetailer
                        {
                            HargaBeli = 0,
                            HargaJual = ppr.HargaJual,
                            Qty = ppr.Qty * -1,
                            IdProdukRetailer = pr.Id,
                            IdProdukRetailerNavigation = pr
                        })

                    .FirstOrDefaultAsync();

            return penjualanProdukRetailer;
        }
    }
}
