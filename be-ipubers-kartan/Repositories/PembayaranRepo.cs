using be_ipubers_kartan.Interface;
using be_ipubers_kartan.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Repositories
{
    public class PembayaranRepo : IPembayaran
    {
        RMSContext _context;
        private readonly string _connectionString;
        public PembayaranRepo(RMSContext context, IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
            _context = context;
        }

        public async Task<Pembayaran> GetPembayaranByKodeProduk(string kodeProduk)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM Petani p WHERE p.NIK = @kodeProduk";
            var result = await connection.QueryFirstOrDefaultAsync<Pembayaran>(sql, new { kodeProduk = kodeProduk });

            if (result == null)
                throw new KeyNotFoundException($"Petani with Nik {kodeProduk} not found.");

            return result;
        }
        public async Task InsertData(Pembayaran model, SqlConnection conn, SqlTransaction sqlTransIpubers)
        {
            try
            {
                string query = @"INSERT INTO Pembayaran 
                        (IdPenjualan, NoPembayaran, TanggalPembayaran, JenisPembayaran, 
                         KartuPembayaran, Jumlah, Catatan, CreatedAt, CreatedBy, Status) 
                         OUTPUT INSERTED.Id
                         VALUES 
                        (@IdPenjualan, @NoPembayaran, @TanggalPembayaran, @JenisPembayaran, 
                         @KartuPembayaran, @Jumlah, @Catatan, @CreatedAt, @CreatedBy, @Status)";

                var result = await conn.QuerySingleAsync<int>(query, new
                {
                    IdPenjualan = model.IdPenjualan,
                    NoPembayaran = model.NoPembayaran,
                    TanggalPembayaran = model.TanggalPembayaran,
                    JenisPembayaran = model.JenisPembayaran,
                    KartuPembayaran = model.KartuPembayaran,
                    Jumlah = model.Jumlah,
                    Catatan = model.Catatan,
                    CreatedAt = model.CreatedAt,
                    CreatedBy = model.CreatedBy,
                    Status = model.Status
                }, transaction: sqlTransIpubers);

                model.Id = result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Pembayaran - {ex.Message}", ex);
            }
        }

        public async Task<int> InsertDataRekan(Models.Rekan.Pembayaran model, SqlConnection conn, SqlTransaction transaction)
        {
            try
            {
                string query = @"insert into Pembayaran (IdPenjualan, NoPembayaran, TanggalPembayaran, JenisPembayaran, 
                                    KartuPembayaran, Jumlah, Catatan, CreatedAt, CreatedBy) 
                                OUTPUT INSERTED.Id
                                values (@IdPenjualan, @NoPembayaran, @TanggalPembayaran, @JenisPembayaran, 
                                    @KartuPembayaran, @Jumlah, @Catatan, @CreatedAt, @CreatedBy)";

                var result = await conn.QuerySingleAsync<int>(query, new
                {
                    IdPenjualan = model.IdPenjualan,
                    NoPembayaran = model.NoPembayaran,
                    TanggalPembayaran = model.TanggalPembayaran,
                    JenisPembayaran = model.JenisPembayaran,
                    KartuPembayaran = model.KartuPembayaran,
                    Jumlah = model.Jumlah,
                    Catatan = model.Catatan,
                    CreatedAt = model.CreatedAt,
                    CreatedBy = model.CreatedBy
                }, transaction:transaction);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Pembayaran Rekan - {ex.Message}");
            }
        }
    }
}
