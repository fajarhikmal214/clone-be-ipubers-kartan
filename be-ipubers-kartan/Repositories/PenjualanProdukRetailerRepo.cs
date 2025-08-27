using be_ipubers_kartan.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Repositories
{
    public class PenjualanProdukRetailerRepo
    {
        private readonly string _connectionString;
        private readonly RMSContext _context;

        public PenjualanProdukRetailerRepo(IConfiguration configuration, RMSContext rMSContext)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
            _context = rMSContext;
        }

        public async Task<string> GetKodeProduk ( string idPenjualan)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = @"SELECT DISTINCT pr.KodeProduk 
                             FROM PenjualanProdukRetailer ppr
                             INNER JOIN ProdukRetailer pr ON ppr.IdProdukRetailer = pr.Id
                             WHERE ppr.IdPenjualan = @IdPenjualan";
            var kodeProduk = await connection.QuerySingleAsync<string>(query, new { IdPenjualan = idPenjualan });
            if (kodeProduk == null || !kodeProduk.Any())
            {
                throw new KeyNotFoundException($"No products found for Penjualan with Id {idPenjualan}.");
            }
            return kodeProduk;
        }
        public async Task InsertData(SqlTransaction trans, Models.PenjualanProdukRetailer model)
        {
            if (trans?.Connection == null)
                throw new InvalidOperationException("Transaksi atau koneksi tidak tersedia (mungkin sudah disposed).");

            if (model.IdPenjualan <= 0)
                throw new ArgumentException("IdPenjualan tidak valid. Tidak bisa insert ke PenjualanProdukRetailer.");

            const string query = @"
            INSERT INTO PenjualanProdukRetailer 
                (IdPenjualan, IdProdukRetailer, HargaJual, HargaBeli, Qty, Catatan, LevelHargaJual) 
            OUTPUT INSERTED.Id
            VALUES 
                (@IdPenjualan, @IdProdukRetailer, @HargaJual, @HargaBeli, @Qty, @Catatan, @LevelHargaJual)";

            try
            {
                var connection = (SqlConnection)trans.Connection;

                int newId = await connection.QuerySingleAsync<int>(
                    query,
                    model,
                    transaction: trans
                );

                model.Id = newId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error PenjualanProduk - {ex.Message}", ex);
            }
        }
        public async Task InsertDataRekan(SqlConnection conn, SqlTransaction transaction, Models.Rekan.PenjualanProdukRetailer model)
        {
            try
            {
                string query = @"insert into PenjualanProdukRetailer (IdPenjualan, IdProdukRetailer, HargaJual, HargaBeli, Qty, Catatan,LevelHargaJual) 
                            OUTPUT INSERTED.Id
                            values (@IdPenjualan, @IdProdukRetailer, @HargaJual, @HargaBeli, @Qty, @Catatan,@LevelHargaJual)";

                int newIdPenjualanProdukRetailer = await conn.QuerySingleAsync<int>(query, new
                {
                    IdPenjualan = model.IdPenjualan,
                    IdProdukRetailer = model.IdProdukRetailer,
                    HargaJual = model.HargaJual,
                    HargaBeli = model.HargaBeli,
                    Qty = model.Qty,
                    Catatan = model.Catatan,
                    LevelHargaJual = model.LevelHargaJual
                }, transaction: transaction);

                model.Id = newIdPenjualanProdukRetailer;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Penjualan Produk Rekan - {ex.Message}");
            }
        }
        public static async Task<int> InsertStokAsync(SqlConnection conn, SqlTransaction transaction, Models.Rekan.ProdukRetailerStok model)
        {
            string query = @"insert into ProdukRetailerStok (IdProdukRetailer,TglTransaksi,KodeTransaksiStok,StokAwal,JumlahStok,StokAkhir,TipeStok,Deskripsi,CreatedBy) 
                                OUTPUT INSERTED.Id
                            values (@IdProdukRetailer,@TglTransaksi,@KodeTransaksi,@StokAwal,@JumlahStok,@StokAkhir,@TipeStok,@Deskripsi,@CreatedBy)";
            try
            {
                var param = new
                {
                    IdProdukRetailer = model.Id,
                    TglTransaksi = model.TglTransaksi,
                    KodeTransaksi = model.KodeTransaksiStok,
                    StokAwal = model.StokAwal,
                    JumlahStok = model.JumlahStok,
                    StokAkhir = model.StokAkhir,
                    TipeStok = model.TipeStok,
                    Deskripsi = model.Deskripsi,
                    CreatedBy = model.CreatedBy
                };

                var result = await conn.QuerySingleAsync<int>(query, param, transaction: transaction);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error ProdukRetailerStok - {ex.Message}");
            }
        }

    }
}
