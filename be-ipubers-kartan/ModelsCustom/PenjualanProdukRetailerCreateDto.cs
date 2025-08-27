using be_ipubers_kartan.Models;

namespace be_ipubers_kartan.ModelsCustom
{
    public class PenjualanProdukRetailerCreateDto
    {
        public ProdukRetailerPenjualanCreateDto ProdukRetailer { get; set; }
        public decimal HargaJual { get; set; }
        public decimal HargaBeli { get; set; }
        public double Qty { get; set; }
        public string Catatan { get; set; }
        public int LevelHargaJual { get; set; }
    }
    public class ProdukRetailerPenjualanCreateDto
    {
        public int Id { get; set; }
        public string KodeProduk { get; set; }
    }
}
