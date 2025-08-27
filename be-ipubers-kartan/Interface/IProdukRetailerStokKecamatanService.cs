using Microsoft.Data.SqlClient;

namespace be_ipubers_kartan.Interface
{
    public interface IProdukRetailerStokKecamatanService
    {
        Task<int> UpdateStokAsync(SqlConnection conn, SqlTransaction transaction, double jumlahStok, int idProdukRetailer, string idKecamatan);
    }
}
