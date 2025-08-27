using System.Text.Json.Serialization;

namespace be_ipubers_kartan.Dtos
{
    public class StokKiosResponseDTO
    {
        public string KodeKios { get; set; }
        
        public string KodeKecamatan { get; set; }
        
        public double Urea { get; set; }

        public double NPK { get; set; }

        public double NPKFK { get; set; }

        public double ORGR { get; set; }

        public double ASZA { get; set; }
    }
}
