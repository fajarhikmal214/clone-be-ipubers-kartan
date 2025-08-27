using be_ipubers_kartan.Models;
using Microsoft.EntityFrameworkCore;
using static be_ipubers_kartan.ModelsCustom.ProdukRetailerStok;

namespace be_ipubers_kartan.ModelsCustom
{
    public class ProdukRetailer
    {
        public int Id { get; set; }
        public KategoriProduk KategoriProduk { get; set; }
        public Retailer Retailer { get; set; }
        public string KodeProduk { get; set; }
        public string NamaProduk { get; set; }
        public string Deskripsi { get; set; }
        public string Satuan { get; set; }
        public string StatusProduk { get; set; }
        public string JenisProduk { get; set; }
        public double Stok { get; set; }
        public decimal NilaiUnit { get; set; }
        public LogInfo LogInfo { get; set; }

        public async Task<ProdukRetailer> CalculateStokUnitPrice(OpsiTipeStok opsiTipeStok, int IdProdukRetailer, double qty, decimal unitValue)
        {
            var latestStok = await this.GetLatestStokUnitPrice(IdProdukRetailer);
            ProdukRetailer produkRetailer = new ProdukRetailer
            {
                Id = IdProdukRetailer,
                Stok = latestStok.Stok - qty
            };

            if (opsiTipeStok == OpsiTipeStok.PENGURANGAN_PENJUALAN || opsiTipeStok == OpsiTipeStok.PEMBATALAN_PENJUALAN)
                produkRetailer.NilaiUnit = latestStok.NilaiUnit;

            if (opsiTipeStok == OpsiTipeStok.PENAMBAHAN_RECEIPT)
                produkRetailer.NilaiUnit = ((latestStok.NilaiUnit * (decimal)latestStok.Stok) + (unitValue * (decimal)qty)) / (decimal)(latestStok.Stok + qty);

            return produkRetailer;
        }

        private async Task<ProdukRetailer> GetLatestStokUnitPrice(int idProdukRetailer)
        {
            using (RMSContext context = new RMSContext())
            {
                var data = await context.ProdukRetailers.Where(e => e.Id.Equals(idProdukRetailer)).FirstOrDefaultAsync();

                this.Id = data.Id;
                this.Stok = (double)data.Stok;
                this.NilaiUnit = (decimal)data.NilaiUnit;

                return this;
            }
        }
    }
}
