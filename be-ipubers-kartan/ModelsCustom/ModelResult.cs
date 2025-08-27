using System.Text.Json.Serialization;

namespace be_ipubers_kartan.ModelsCustom
{
    public class ModelResult
    {
        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }
        [JsonPropertyName("statusDesc")]
        public string StatusDesc { get; set; }
        [JsonPropertyName("statusDescHeading")]
        public string StatusDescHeading { get; set; }
        [JsonPropertyName("data")]
        public object Data { get; set; }
    }
}
