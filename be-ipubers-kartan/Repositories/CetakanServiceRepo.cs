using Microsoft.Extensions.Caching.Memory;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using be_ipubers_kartan.Interface;
using be_ipubers_kartan.Dtos;

namespace be_ipubers_kartan.Repositories
{
    public class CetakanServiceRepo : ICetakanService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMemoryCache _memoryCache;

        public CetakanServiceRepo(HttpClient httpClient, IConfiguration config, IHttpClientFactory httpClientFactory, IMemoryCache memoryCache)
        {
            _httpClient = httpClient;
            _config = config;
            _httpClientFactory = httpClientFactory;
            _memoryCache = memoryCache;
        }

        public async Task<ResponseLoginCetakanService> LoginAsync()
        {
            if (_memoryCache.TryGetValue("CetakanServiceToken", out string cachedToken) &&
                _memoryCache.TryGetValue("CetakanServiceToken_ExpireTime", out DateTime validTo))
            {
                Console.WriteLine("ini adalah waktu server : {0}, ini adalah waktu validTo: {1}", DateTime.Now, validTo);
                if (DateTime.Now < validTo)
                {
                    Console.WriteLine("ini adalah waktu server : {0}, ini adalah waktu validTo: {1}", DateTime.Now, validTo);
                    return new ResponseLoginCetakanService
                    {
                        token = cachedToken,
                        userName = _memoryCache.Get<string>("CetakanServiceToken_UserName") ?? "Unknown"
                    };
                }
            }

            var loginData = new CetakanServiceDtos
            {
                UserName = _config.GetValue<string>("CetakanService:Username")!,
                Password = _config.GetValue<string>("CetakanService:Password")!
            };

            var json = JsonConvert.SerializeObject(loginData);

            var baseURL = _config.GetValue<string>("CetakanService:BaseUrl");
            var authEndpoint = _config.GetValue<string>("CetakanService:Endpoint:Auth");

            var url = $"{baseURL}{authEndpoint}";

            var client = _httpClientFactory.CreateClient("CetakanService");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            var tokenResponse = JObject.Parse(responseJson);

            var token = tokenResponse["token"]?.ToString();
            var username = tokenResponse["user"]?["userName"]?.ToString() ?? "Unknown";
            var validToString = tokenResponse["validTo"]?.ToString();

            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Token tidak ditemukan dalam respons API.");
            }

            if (!DateTime.TryParse(validToString, out DateTime validToUtc))
            {
                throw new Exception("Format validTo tidak valid.");
            }

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(validToUtc);

            _memoryCache.Set("CetakanServiceToken", token, cacheEntryOptions);
            _memoryCache.Set("CetakanServiceToken_ExpireTime", validToUtc, cacheEntryOptions);
            _memoryCache.Set("CetakanServiceToken_UserName", username, cacheEntryOptions);

            var result = new ResponseLoginCetakanService
            {
                token = token,
                userName = username,
            };

            return result;
        }
    }
}
