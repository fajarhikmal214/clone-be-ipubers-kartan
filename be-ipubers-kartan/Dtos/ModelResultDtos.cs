using be_ipubers_kartan.ModelsCustom;
using System.Text.Json.Serialization;

namespace be_ipubers_kartan.Dtos
{
    public class ModelResultDtos
    {
        public int StatusCode { get; set; }
        
        public string? StatusDesc { get; set; }
        
        public string? StatusDescHeading { get; set; }
        
        public object? Data { get; set; }
    }
}
