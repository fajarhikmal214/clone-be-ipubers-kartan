using be_ipubers_kartan.Dtos;
using be_ipubers_kartan.Models;

namespace be_ipubers_kartan.Interface
{
    public interface ISyncAlokasiService
    {
        Task<ValidasiAlokasiResponse> CekAlokasi(AlokasiRequesDto request, string idRetailer, string token, Penjualan penjualan, CancellationToken cancellationToken);
    }
}
