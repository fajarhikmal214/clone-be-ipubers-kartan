using be_ipubers_kartan.Interface;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace be_ipubers_kartan.Repositories
{
    public class ProdukRetailerStokKecamatanRekanRepo : IProdukRetailerStokKecamatanService
    {
        public async Task<int> UpdateStokAsync(SqlConnection conn, SqlTransaction transaction, double jumlahStok, int idProdukRetailer, string idKecamatan)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string qUpdateStokKec = @"
                    UPDATE 
                        ProdukRetailerStokKecamatan 
                    SET
                        stok = stok - @qty 
                    where 
                        IdProdukRetailer = @idProdukRetailer 
                        AND IdKecamatan = @idKecamatan";

                DynamicParameters parameterStokKec = new DynamicParameters();
                parameterStokKec.Add("qty", jumlahStok);
                parameterStokKec.Add("idProdukRetailer", idProdukRetailer);
                parameterStokKec.Add("idKecamatan", idKecamatan);

                var resUpdateStokKec = await conn.ExecuteAsync(qUpdateStokKec, parameterStokKec, transaction);
                return resUpdateStokKec;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error ProdukRetailerStokKecamatan - {ex.Message}");
            }
        }

    }
}
