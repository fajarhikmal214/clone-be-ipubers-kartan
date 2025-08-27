namespace be_ipubers_kartan.Dtos
{
    public class StokKiosDto
    {
        public string KodeProduk { get; set; }
        public string Produk { get; set; }
        public string Satuan { get; set; }
        public string KodeKios { get; set; }
        public string Gambar { set; get; }
        public double? Stok { get; set; }
        public string? IdKecamatan { set; get; }
        public string? Kecamatan { set; get; }
    }
}
