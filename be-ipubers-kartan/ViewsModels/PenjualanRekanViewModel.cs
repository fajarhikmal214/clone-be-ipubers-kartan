using be_ipubers_kartan.Models;
using be_ipubers_kartan.ModelsCustom.ViewsModelCustom;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.ViewsModels
{
    public class PenjualanRekanViewModel
    {
        private readonly RMSContext _dbContext;

        public PenjualanRekanViewModel(RMSContext context)
        {
            _dbContext = context;

        }
        public async Task<VMCPenjualanCreateDto> CreateModelPenjualanFromNota(string noNota)
        {
            try
            {
                var dataPenjualan = await _dbContext.Penjualans
                    .Include(x => x.IdPetaniNavigation)
                    .Where(w => w.NoNota == noNota).FirstOrDefaultAsync();
                var penjualanProdukRetailerCreateDto = await _dbContext.PenjualanProdukRetailers
                    .Where(w => w.IdPenjualan == dataPenjualan.Id)
                    .Join(_dbContext.ProdukRetailers.Where(w => w.IdRetailer == dataPenjualan.IdRetailer),
                    a => new { IdProdukRetailer = a.IdProdukRetailer },
                    b => new { IdProdukRetailer = b.Id },
                    (a, b) =>
                    new ModelsCustom.PenjualanProdukRetailerCreateDto
                    {
                        Catatan = a.Catatan ?? string.Empty,
                        HargaBeli = 0,
                        HargaJual = a.HargaJual,
                        ProdukRetailer = new ModelsCustom.ProdukRetailerPenjualanCreateDto
                        {
                            KodeProduk = b.KodeProduk
                        },
                        Qty = a.Qty
                    }).ToListAsync();

                //if (penjualanProdukRetailerCreateDto.Count == 0)
                //    throw new Exception("Penjualan Produk Retailer tidak ditemukan");

                VMCPenjualanCreateDto model = new VMCPenjualanCreateDto
                {
                    Penjualan = new ModelsCustom.Penjualan
                    {
                        Catatan = dataPenjualan.Catatan ?? string.Empty,
                        FotoKTPPembeli = dataPenjualan.FotoKtppembeli ?? string.Empty,
                        FotoKTPPembeliLokasi = dataPenjualan.FotoKtppembeliLokasi ?? string.Empty,
                        FotoKTPPembeliWaktu = DateTime.Now,
                        FotoKTPPemilik = dataPenjualan.FotoKtppemilik ?? string.Empty,
                        FotoKTPPemilikLokasi = dataPenjualan.FotoKtppemilikLokasi ?? string.Empty,
                        FotoKTPPemilikWaktu = DateTime.Now,
                        JenisPenjualan = dataPenjualan.JenisPenjualan ?? string.Empty,
                        FotoKtpPerwakilan = dataPenjualan.FotoKtpPerwakilan ?? string.Empty,
                        SwaFotoPerwakilan = dataPenjualan.SwaFotoPerwakilan ?? string.Empty,
                        SuratPernyataan = dataPenjualan.SuratPernyataan ?? string.Empty,
                        BuktiPenyaluranPetani = string.IsNullOrEmpty(dataPenjualan.BuktiPenyaluranPetani) ? "https://firebasestorage.googleapis.com/v0/b/psp-kementan.appspot.com/o/image_static%2Fimage_blank.jpeg?alt=media&token=2a72801c-241a-4ecd-9bf0-9fb24b10bc60" : dataPenjualan.BuktiPenyaluranPetani,
                        BuktiKtpBeda = dataPenjualan.BuktiKtpBeda ?? string.Empty,
                        Nama = dataPenjualan.Nama,
                        NoHp = dataPenjualan.NoHp,
                        NoNota = dataPenjualan.NoNota,
                        NoReferensi = dataPenjualan.NoReferensi ?? string.Empty,
                        Status = dataPenjualan.Status ?? string.Empty,
                        TandaTangan = dataPenjualan.TandaTangan ?? string.Empty,
                        TanggalJatuhTempo = dataPenjualan.TanggalJatuhTempo is null ? dataPenjualan.TanggalNota : dataPenjualan.TanggalJatuhTempo.Value,
                        TanggalNota = dataPenjualan.TanggalNota,
                        Petani = new ModelsCustom.Petani
                        {
                            Id = dataPenjualan.IdPetani,
                            NIK = dataPenjualan.IdPetaniNavigation.Nik,
                            NamaPetani = dataPenjualan.IdPetaniNavigation.NamaPetani,
                            NoHp = dataPenjualan.IdPetaniNavigation.NoHp ?? string.Empty,
                            KelompokTani = dataPenjualan.IdPetaniNavigation.KelompokTani ?? string.Empty
                        },
                        Retailer = new ModelsCustom.Retailer
                        {
                            Code = dataPenjualan.IdRetailer
                        },
                        PoktanId = dataPenjualan.PoktanId is null ? 0 : dataPenjualan.PoktanId.Value,
                        KodeDesa = dataPenjualan.KodeDesa ?? string.Empty,
                        Source = dataPenjualan.Source, //auto by system,
                        IdKomoditas = dataPenjualan.KomoditiId.ToString(),
                        BatchId = dataPenjualan.BatchId ?? string.Empty
                    },
                    PenjualanProdukRetailer = penjualanProdukRetailerCreateDto,
                    Potongan = 0,
                    Pembayaran = new ModelsCustom.Pembayaran
                    {
                        Catatan = "-",
                        JenisPembayaran = "1",
                        Jumlah = penjualanProdukRetailerCreateDto.Sum(s => Convert.ToDecimal(s.Qty) * s.HargaJual),
                        KartuPembayaran = string.Empty,
                        TanggalPembayaran = dataPenjualan.CreatedAt
                    },
                    ProdukRetailerStok = new List<ModelsCustom.ProdukRetailerStok>(),
                    NamaPoktan = dataPenjualan.NamaPoktan 
                };

                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
