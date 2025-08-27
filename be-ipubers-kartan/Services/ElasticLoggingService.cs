using be_ipubers_kartan.Dtos;
using be_ipubers_kartan.Interface;
using Nest;

namespace be_ipubers_kartan.Services
{
    public class ElasticLoggingService : IElasticLoggingService
    {
        private readonly IConfiguration _configuration;
        private readonly IElasticClient _elasticClient;

        public ElasticLoggingService(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _configuration = configuration;
            _elasticClient = serviceProvider.GetService<IElasticClient>();
        }

        public async Task IndexErrorLogAsync(ExceptionLogDto errorLog)
        {
            var appName = "ipubers-kartan-api";
            var environment = _configuration["AppSettings:EnvironmentName"] != "Production" ? "dev-" : "";
            var dateSuffix = DateTime.UtcNow.ToString("yyyy-MM");

            var indexName = $"{appName}-logs-{environment}{dateSuffix}";
            var response = await _elasticClient.IndexAsync(errorLog, idx => idx.Index(indexName));

            if (!response.IsValid)
            {
                // optional fallback logger
                Console.WriteLine("Failed to index log to Elasticsearch:");
                Console.WriteLine(response.DebugInformation);
            }
        }
    }
}