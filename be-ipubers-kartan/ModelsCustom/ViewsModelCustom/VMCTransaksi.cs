

namespace be_ipubers_kartan.ModelsCustom.ViewsModelCustom
{
    public class VMCTransaksi
    {
        public Penjualan Penjualan { get; set; }
        public List<PenjualanDetail> PenjualanDetail { get; set; }
        public List<PenjualanProdukRetailerCreateDto> PenjualanProdukRetailer { get; set; }
        public Pembayaran Pembayaran { get; set; }
        public decimal? Potongan { get; set; }
        public List<ProdukRetailerStok> ProdukRetailerStok { get; set; }
        public List<RiwayatTransaksi> ListRiwayatTransaksi { get; set; }

    }

    public class VMCPenjualanCreateDto
    {
        public Penjualan Penjualan { get; set; }
        public List<PenjualanDetail> PenjualanDetail { get; set; }
        public List<PenjualanProdukRetailerCreateDto> PenjualanProdukRetailer { get; set; }
        public Pembayaran Pembayaran { get; set; }
        public decimal? Potongan { get; set; }
        public string NamaPoktan { get; set; }
        public string? FcmToken { get; set; }
        public List<ProdukRetailerStok> ProdukRetailerStok { get; set; }
        public List<RiwayatTransaksi> ListRiwayatTransaksi { get; set; }
    }
}
