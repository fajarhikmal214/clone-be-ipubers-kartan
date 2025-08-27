using be_ipubers_kartan.Models.Rekan;
using Microsoft.Data.SqlClient;

namespace be_ipubers_kartan.Interface
{
    public interface IProdukRetailerStokRekanService
    {
        Task<int> UpdateStokAsync(ProdukRetailerStok model, SqlConnection conn, SqlTransaction transactionRekan);
    }
}
