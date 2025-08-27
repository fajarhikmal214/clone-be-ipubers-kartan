using be_ipubers_kartan.Dtos;
using be_ipubers_kartan.Models;
using Microsoft.Data.SqlClient;

namespace be_ipubers_kartan.Interface
{
    public interface ITransaksiKartanService
    {
        Task<T> GetDataPetani<T>(string nik, string? source);
        Task<MasterKelompokTani> GetDataPoktanPetani(string idpoktan);
        Task<IEnumerable<LastNumberDtos>> LastNumber(string prefix, string idRetailer, int startIndex = 2);
        Task<decimal> GetHargaJual(string kodeProduk);
        Task<List<TransaksiAndReversalDto>> GetListTransaksiByRefnumAndRetailerId(string idRetailer, string refnum);
        Task<List<Penjualan>> GetListTransaksiByRefnum(string refnum);
        Task<Models.Rekan.Penjualan> GetRekanTransaksiByNota(string noNota);
        Task<List<Penjualan>> GetListNoNotaByMultipleRefnum(List<string> refnums);
        Task<PenjualanProdukRetailer> GetPenjualanProdukRetailerIpubers(int id, string idRetailer);
        Task<Models.Rekan.PenjualanProdukRetailer> GetPenjualanProdukRetailerRekan(int id, string idRetailer);

        //int InsertData(Penjualan penjualan);
    }
}
