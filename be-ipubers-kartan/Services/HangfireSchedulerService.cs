using Hangfire;
using be_ipubers_kartan.Jobs;

namespace be_ipubers_kartan.Services
{
    public class HangfireSchedulerService : IHostedService
    {
        private readonly ILogger<HangfireSchedulerService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IRecurringJobManager _recurringJobManager;

        public HangfireSchedulerService(ILogger<HangfireSchedulerService> logger, IConfiguration configuration, IRecurringJobManager recurringJobManager)
        {
            _logger = logger;
            _configuration = configuration;
            _recurringJobManager = recurringJobManager;
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("HangfireSchedulerService is starting. Scheduling recurring jobs...");

            // Daily cron 01:00 AM
            string cron = "0 18 * * *"; // 18:00 UTC = 01:00 Asia/Jakarta

            _recurringJobManager.AddOrUpdate<RekonTransaksiJob>("rekon-transaksi-job", job => job.RekonTransaksi(), cron);
            _recurringJobManager.AddOrUpdate<LatestDataStokJob>("latest-data-stok-job", job => job.LatestDataStok(), cron);

            _logger.LogInformation("Recurring job scheduled");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("HangfireSchedulerService is stopping.");
            return Task.CompletedTask;
        }
    }
}