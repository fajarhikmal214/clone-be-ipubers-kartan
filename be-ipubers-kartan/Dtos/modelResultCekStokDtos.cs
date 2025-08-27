using System.Text.Json.Serialization;

namespace be_ipubers_kartan.Dtos
{
    public class ModelResultCekStokDto
    {
        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }
        [JsonPropertyName("statusDesc")]
        public string StatusDesc { get; set; }
        [JsonPropertyName("statusDescHeading")]
        public string StatusDescHeading { get; set; }
        [JsonPropertyName("data")]
        public List<StokProduk> Data { get; set; }
    }
    public class StokProduk
    {

        [JsonPropertyName("kodeKios")]
        public string KodeKios { get; set; }
        [JsonPropertyName("kodeProduk")]
        public string KodeProduk { get; set; }
        [JsonPropertyName("produk")]
        public string Produk { get; set; }
        [JsonPropertyName("stok")]
        public double Stok { get; set; }
        [JsonPropertyName("gambar")]
        public string Gambar { get; set; }
        [JsonPropertyName("satuan")]
        public string Satuan { get; set; }
    }
}
