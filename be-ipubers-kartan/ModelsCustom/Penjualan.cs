using System.ComponentModel.DataAnnotations;

namespace be_ipubers_kartan.ModelsCustom
{
    public enum StatusPenjualan
    {
        INVOICE = 1,
        PAID = 2,
        RETURN = 3
    }
    public enum JenisPenjualan
    {
        SUBSIDI = 1,
        NONSUBSIDI = 2
    }
    public class Penjualan
    {
        public int Id { get; set; }
        public string NoNota { get; set; }
        public Retailer Retailer { get; set; }
        public Petani Petani { get; set; }
        public PelangganPenjualanCreateDto PelangganRetailer { get; set; } = new PelangganPenjualanCreateDto();
        public string Nama { get; set; }
        public string NoHp { get; set; }
        [Required(ErrorMessage = "Tanggal wajib diisi")]
        public DateTime TanggalNota { get; set; }
        public DateTime TanggalJatuhTempo { get; set; }
        public string FotoKTPPembeli { get; set; }
        public string FotoKTPPembeliLokasi { get; set; }
        public DateTime? FotoKTPPembeliWaktu { get; set; } = DateTime.Now;
        public string FotoPembeliKendaraan { get; set; }
        public string FotoKTPPemilik { get; set; }
        public string FotoKTPPemilikLokasi { get; set; }
        public DateTime? FotoKTPPemilikWaktu { get; set; } = DateTime.Now;
        public string TandaTangan { get; set; }
        public string JenisPenjualan { get; set; }
        public string Status { get; set; }
        //bisa digunakan jika ada retur/refund untuk referenced id
        public string NoReferensi { get; set; }
        public string Catatan { get; set; }
        public LogInfo LogInfo { get; set; }
        public string IdBag { get; set; }
        public int PoktanId { get; set; }
        public string KodeDesa { get; set; }
        public int Source { get; set; }
        public dynamic? IdKomoditas { get; set; }
        public string FotoKtpPerwakilan { get; set; }
        public string SwaFotoPerwakilan { get; set; }
        public string NamaPerwakilan { get; set; }
        public string BatchId { get; set; }
        public string SuratPernyataan { get; set; }
        public string BuktiPenyaluranPetani { get; set; }
        public string BuktiKtpBeda { get; set; }
        public string NikPerwakilan { get; set; }
        public int? StatusVerval { get; set; }
        public string IdBilling { get; set; }
        public string NamaPoktan { get; set; }
        public string? KodePelanggan { get; set; }

        public static implicit operator Penjualan(Models.Penjualan v)
        {
            throw new NotImplementedException();
        }
    }
    public partial class PelangganPenjualanCreateDto
    {
        public string Kode { get; set; }
    }
}
