namespace be_ipubers_kartan.Dtos
{
    public class CheckStokGlobal
    {
        public string KodeProduk { set; get; }
        public double? Stok { set; get; }
    }

    public class CekStokByRefNum
    {
        public string KodeProduk { set; get; }
        public string IdRetailer { set; get; }
        public string IdKecamatan { set; get; }
    }

    public class CekStokByKecamatan
    {
        public required string IdKecamatan { set; get; }
        public required string NamaKecamatan { set; get; }
        public double Stok { set; get; }
    }
}
