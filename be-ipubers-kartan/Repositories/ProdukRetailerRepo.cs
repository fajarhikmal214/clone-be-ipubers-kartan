using be_ipubers_kartan.Dtos;
using be_ipubers_kartan.Helpers;
using be_ipubers_kartan.Interface;
using be_ipubers_kartan.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Repositories
{
    public class ProdukRetailerRepo : IProdukRetailerService
    {
        private readonly IConfiguration _config;
        private readonly RMSContext _rMSContext;
        private readonly string _connectionString;
        private readonly string _rekanConn;

        public ProdukRetailerRepo(IConfiguration config, RMSContext rMSContext)
        {
            _config = config;
            _rMSContext = rMSContext;
            _connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
            _rekanConn = config.GetConnectionString("RekanConnection") ?? throw new InvalidOperationException("Connection string 'RekanConnection' is not configured.");
        }

        public List<Models.ProdukRetailer> GetByRetailer(string idRetailer)
        {
            string query = @"select id,  
                                         idretailer,  
                                         kodeproduk,  
                                         namaproduk,  
                                         satuan,  
                                         jenisproduk,  
                                         isnull(stok,0) Stok  
                                  from ProdukRetailer a  
                                  where IdRetailer = @idRetailer";

            var queryHelper = new QueryHelper(_config);
            var data = queryHelper.SelectData<Models.ProdukRetailer>(query, new { idRetailer });

            return data.ToList();
        }
        public async Task<Models.ProdukRetailer> GetByProdukNRetailer(string idProdukRetailer, string kodeProduk)
        {
            string query = @"SELECT * FROM ProdukRetailer pr 
                   WHERE pr.IdRetailer = @idRetailer AND pr.KodeProduk = @kodeProduk";

            var queryHelper = new QueryHelper(_config);
            var data = await Task.Run(() => queryHelper.SelectData<Models.ProdukRetailer>(query, new { idRetailer = idProdukRetailer, kodeProduk = kodeProduk }).FirstOrDefault());

            if (data == null)
            {
                throw new KeyNotFoundException($"ProdukRetailer with IdRetailer {idProdukRetailer} and KodeProduk {kodeProduk} not found.");
            }

            return data;
        }

        public async Task<ProdukRetailer> GetProdukRetailer(string idRetailer, string kodeProduk, string source = "ipubers")
        {
            string connectionString = source == "ipubers" ? _connectionString : _rekanConn;
            using var connection = new SqlConnection(connectionString);

            string query = @"
                SELECT 
                    pr.id,
                    pr.IdRetailer,
                    pr.Stok,
                    pr.KodeProduk,
                    pr.NamaProduk
                FROM
                    ProdukRetailer pr
                WHERE
                    pr.IdRetailer = @idRetailer
                    AND pr.KodeProduk = @kodeProduk";

            var result = await connection.QueryFirstOrDefaultAsync<ProdukRetailer>(query, new { idRetailer, kodeProduk });

            if (result == null)
                throw new KeyNotFoundException($"ProdukRetailer with IdRetailer {idRetailer} and KodeProduk {kodeProduk} not found.");

            return result;
        }


        public async Task<int> UpdateStokAsyncToRekan(Models.Rekan.ProdukRetailer model, SqlTransaction transRekan)
        {
            try
            {
                var conn = transRekan.Connection;

                string query = "UPDATE ProdukRetailer WITH (UPDLOCK, ROWLOCK) SET Stok = @Stok WHERE Id = @Id";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("Stok", model.Stok);
                parameter.Add("Id", model.Id);

                var result = await conn.ExecuteAsync(query, parameter, transaction: transRekan);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Update Stok : {ex.Message}");
            }
        }
        public async Task<int> UpdateStokAsync(UpdateProdukRetailerStokIpubersDtos model, SqlTransaction sqlTransIpubers)
        {
            try
            {
                var conn = sqlTransIpubers.Connection;
                string query = "UPDATE ProdukRetailer SET Stok = @Stok WHERE Id = @Id";

                var result = await conn.ExecuteAsync(query, new { Stok = model.Stok, Id = model.Id }, transaction: sqlTransIpubers);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Update Stok : {ex.Message}", ex);
            }
        }
    }
}
