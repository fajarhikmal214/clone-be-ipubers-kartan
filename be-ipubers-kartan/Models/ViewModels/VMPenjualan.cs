namespace be_ipubers_kartan.Models.ViewModels
{
    public class VMPenjualan
    {
        public Penjualan Penjualan { get; set; }
        public List<PenjualanDetail> PenjualanDetail { get; set; }
        public List<PenjualanProdukRetailer> PenjualanProdukRetailer { get; set; }
        public Pembayaran Pembayaran { get; set; }
        public decimal? Potongan { get; set; }
        public string NamaPoktan { get; set; }
        public List<ProdukRetailerStok> ProdukRetailerStok { get; set; }
        public List<RiwayatTransaksi> ListRiwayatTransaksi { get; set; }

        public List<PenjualanProdukRetailerAlokasi> PenjualanProdukRetailerAlokasis { get; set; }
    }
}
