namespace be_ipubers_kartan.Models.ViewModels
{
    public class VMTransaksi
    {
        public Penjualan? Penjualan { get; set; }
        //public List<PenjualanDetail>? PenjualanDetail { get; set; }
        public List<PenjualanProdukRetailer>? PenjualanProdukRetailer { get; set; }
        //public Pembayaran? Pembayaran { get; set; }
        //public decimal? Potongan { get; set; }
        //public string? NamaPoktan { get; set; }
        //public List<ProdukRetailerStok>? ProdukRetailerStok { get; set; }
        //public List<RiwayatTransaksi>? ListRiwayatTransaksi { get; set; }
        //public List<PenjualanProdukRetailerAlokasi>? PenjualanProdukRetailerAlokasis { get; set; }
    }
    public class VMPenjualanCreateDto
    {
        public ModelsCustom.Penjualan Penjualan { get; set; }
        public List<PenjualanDetail> PenjualanDetail { get; set; }
        public List<PenjualanProdukRetailerCreateDto> PenjualanProdukRetailer { get; set; }
        public Pembayaran Pembayaran { get; set; }
        public decimal? Potongan { get; set; }
        public string NamaPoktan { get; set; }
        public string? FcmToken { get; set; }
        public List<ProdukRetailerStok> ProdukRetailerStok { get; set; }
        public List<RiwayatTransaksi> ListRiwayatTransaksi { get; set; }
    }

    public class RiwayatTransaksi
    {
        public int Id { get; set; }
        public string? NoNota { get; set; }
        public string? Nama { get; set; }
        public string? Status { get; set; }
        public DateTime TanggalNota { get; set; }
        public string? JenisProduk { get; set; }
        public string? JenisTransaksi { get; set; }
        public string? NamaKategori { get; set; }
        public decimal NominalPenjualan { get; set; }
        public decimal TotalQty { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Source { get; set; }
        public string? Komoditas { get; set; }
    }
}
