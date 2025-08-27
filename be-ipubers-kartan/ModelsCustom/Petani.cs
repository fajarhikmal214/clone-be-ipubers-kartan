using System.ComponentModel.DataAnnotations;

namespace be_ipubers_kartan.ModelsCustom
{
    public class Petani
    {
        public int Id { get; set; }
        public String NamaPetani { get; set; }

        [MinLength(16, ErrorMessage = "NIK Minimal 16 karaketer")]
        public string NIK { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "NoHP harus berisi angka")]
        public string NoHp { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string KelompokTani { get; set; }
        public string FotoKTP1 { get; set; }
        public string FotoKTP2 { get; set; }
        public int isPetaniRDKK { get; set; }
        public string StatusPetani { get; set; }
        [StringLength(500)]
        public string WajahTampakDepan { get; set; }
        [StringLength(500)]
        public string WajahTampakKanan { get; set; }
        [StringLength(500)]
        public string WajahTampakKiri { get; set; }
        [StringLength(500)]
        public string VideoWajah { get; set; }
        [StringLength(500)]
        public string FotoKTP { get; set; }
        [StringLength(500)]
        public string SwafotoKTP { get; set; }
        public LogInfo LogInfo { get; set; }
    }
}
