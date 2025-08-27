namespace be_ipubers_kartan.ModelsCustom
{
    public class Pembayaran
    {
        public int Id { get; set; }
        public Penjualan Penjualan { get; set; }
        public string NoPembayaran { get; set; }
        public DateTime? TanggalPembayaran { get; set; }
        public string JenisPembayaran { get; set; }
        public string KartuPembayaran { get; set; }
        public decimal Jumlah { get; set; }
        public string Catatan { get; set; }
        public int Status { get; set; }
        public LogInfo LogInfo { get; set; }
    }
}
