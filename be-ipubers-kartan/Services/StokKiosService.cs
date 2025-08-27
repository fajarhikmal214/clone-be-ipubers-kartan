using be_ipubers_kartan.Dtos;
using be_ipubers_kartan.Repositories;

namespace be_ipubers_kartan.Services
{
    public interface IStokKiosService
    {
        Task<List<StokKiosResponseDTO>> CheckStok(StokKiosRequestDTO request);
    }

    public class StokKiosService : IStokKiosService
    {
        private readonly ICekStokRepo _stokKiosRepo;

        public StokKiosService(ICekStokRepo stokKiosRepo)
        {
            _stokKiosRepo = stokKiosRepo;
        }

        public async Task<List<StokKiosResponseDTO>> CheckStok(StokKiosRequestDTO request)
        {
            string[] productIds = { "UN46", "NPKP", "NPKFK", "ORGR", "ASZA" };
            var retailers = await _stokKiosRepo.GetPkpByKecamatan(request.IdKecamatan, request.IdRetailer);

            string[] retailerIds = retailers.Select(s => s.KodeRetailer).Distinct().ToArray();
            var retailerStock = await _stokKiosRepo.GetRetailerStock(request.IdKecamatan, retailerIds, productIds);

            var groupedRetailerStock = retailerStock
                .GroupBy(x => new
                {
                    x.KodeKios,
                    x.KodeProduk,
                    x.Produk,
                    x.Stok,
                    x.Satuan,
                    x.Gambar,
                    x.IdKecamatan,
                    x.Kecamatan
                })
                .Select(y => new StokKiosDto
                {
                    KodeKios = y.Key.KodeKios,
                    KodeProduk = y.Key.KodeProduk,
                    Produk = y.Key.Produk,
                    Stok = y.Key.Stok,
                    Satuan = y.Key.Satuan,
                    Gambar = y.Key.Gambar,
                    IdKecamatan = y.Key.IdKecamatan,
                    Kecamatan = y.Key.Kecamatan
                }).ToList();

            var stokKios = new List<StokKiosDto>();

            List<StokKiosResponseDTO> result = new();

            foreach (var item in groupedRetailerStock)
            {
                var newItem = result.Find(x => x.KodeKios == item.KodeKios) ?? new StokKiosResponseDTO
                {
                    KodeKios = item.KodeKios,
                    KodeKecamatan = item.IdKecamatan,
                    Urea = 0,
                    NPK = 0,
                    NPKFK = 0,
                    ORGR = 0,
                    ASZA = 0
                };

                switch (item.KodeProduk)
                {
                    case "UN46":
                        newItem.Urea = (double)item?.Stok;
                        break;
                    case "NPKP":
                        newItem.NPK = (double)item?.Stok;
                        break;
                    case "NPKFK":
                        newItem.NPKFK = (double)item?.Stok;
                        break;
                    case "ORGR":
                        newItem.ORGR = (double)item?.Stok;
                        break;
                    case "ASZA":
                        newItem.ASZA = (double)item?.Stok;
                        break;
                }

                if (!result.Contains(newItem))
                {
                    result.Add(newItem);
                }
            }

            return result;
        }
    }
}