using System.ComponentModel.DataAnnotations;

namespace be_ipubers_kartan.ModelsCustom
{
    public class Retailer
    {
        public string Code { get; set; }
        public string Nama { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Owner { get; set; }

        [StringLength(16, ErrorMessage = "NIK harus 16 karaketer")]
        public string NIK { get; set; }
        public string NPWP { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string NoSIUP { get; set; }
        public string KodeSIN { get; set; }
        public string FotoNPWP { get; set; }
        public string FotoKTP { get; set; }
        public string FotoKios { get; set; }
        public string FotoGudang { get; set; }
        public int Tipe { get; set; }
        public double LokasiLong { get; set; }
        public double LokasiLat { get; set; }
        public LogInfo LogInfo { get; set; }
        public string IdKecamatan { get; set; }
    }
}
