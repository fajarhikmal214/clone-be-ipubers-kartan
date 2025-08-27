using be_ipubers_kartan.Dtos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace be_ipubers_kartan.Repositories
{
    public interface IRetailerRepo
    {
        Task<CekStokByRefNum> getRetailerByRefNum(string refnum);
    }
    public class RetailerRepo : IRetailerRepo
    {
        private readonly string _connectionString;
        public RetailerRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("RekanConnection") ?? throw new InvalidOperationException("Connection string 'RekanConnection' is not configured.");
        }

        public async Task<CekStokByRefNum> getRetailerByRefNum(string refnum)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = @"
                SELECT 
                    p.IdRetailer as 'IdRetailer',
                    pr.KodeProduk as 'KodeProduk',
                    a.district_code as 'IdKecamatan'
                FROM
                    Penjualan p 
                LEFT JOIN PenjualanProdukRetailer ppr ON p.Id = ppr.IdPenjualan
                LEFT JOIN ProdukRetailer pr ON ppr.IdProdukRetailer = pr.Id
                LEFT JOIN _areas a on a.sub_district_code = p.KodeDesa
                WHERE 
                    p.NoReferensi = @RefNum
            ";

            var result = await connection.QueryFirstOrDefaultAsync<CekStokByRefNum>(query, new { RefNum = refnum });
            if (result == null)
            {
                throw new Exception("Retailer not found for the given reference number.");
            }

            return result;
        }

    }
}
