using be_ipubers_kartan.Models;
using Microsoft.Data.SqlClient;

namespace be_ipubers_kartan.Interface
{
    public interface IPembayaran
    {
        Task<Pembayaran> GetPembayaranByKodeProduk(string kodeProduk);
        Task InsertData(Pembayaran model, SqlConnection conn, SqlTransaction sqlTransIpubers);
        Task<int> InsertDataRekan(Models.Rekan.Pembayaran model, SqlConnection conn, SqlTransaction transaction);
    }
}
