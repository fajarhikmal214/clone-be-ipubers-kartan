using be_ipubers_kartan.Dtos;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace be_ipubers_kartan.Interface
{
    public interface IProdukRetailerService
    {
        List<Models.ProdukRetailer> GetByRetailer(string idRetailer);
        Task<Models.ProdukRetailer> GetByProdukNRetailer(string idProdukRetailer, string kodeProduk);
        Task<Models.ProdukRetailer> GetProdukRetailer(string idProdukRetailer, string kodeProduk, string? source);
        Task<int> UpdateStokAsyncToRekan(Models.Rekan.ProdukRetailer model, SqlTransaction sqlTransIpubers);
        Task<int> UpdateStokAsync(UpdateProdukRetailerStokIpubersDtos model, SqlTransaction sqlTransIpubers);
    }
}
