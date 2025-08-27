using System.Text.Json.Serialization;

namespace be_ipubers_kartan.Dtos
{
    public class LoginResponseDto
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        [JsonPropertyName("issuedAt")]
        public string IssuedAt { get; set; }

        [JsonPropertyName("validTo")]
        public DateTime ValidTo { get; set; }

        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
