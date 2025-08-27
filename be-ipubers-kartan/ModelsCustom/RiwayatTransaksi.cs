using be_ipubers_kartan.ModelsCustom.ViewsModelCustom;

namespace be_ipubers_kartan.ModelsCustom
{
    public class RiwayatTransaksi : VMLampiran9Satuan
    {
        public int Id { get; set; }
        public string NoNota { get; set; }
        public string Nama { get; set; }
        public string Status { get; set; }
        public DateTime TanggalNota { get; set; }
        public string JenisProduk { get; set; }
        public string JenisTransaksi { get; set; }
        public string NamaKategori { get; set; }
        public decimal NominalPenjualan { get; set; }
        public decimal TotalQty { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Source { get; set; }
        public string Komoditas { get; set; }
    }
}
