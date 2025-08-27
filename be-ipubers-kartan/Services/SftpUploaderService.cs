using Renci.SshNet;

namespace be_ipubers_kartan.Services
{
    public class SftpUploaderService
    {
        private readonly ILogger<SftpUploaderService> _logger;
        private readonly IConfiguration _configuration;
        private readonly SftpSettings _sftpSettings;

        public SftpUploaderService(ILogger<SftpUploaderService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _sftpSettings = _configuration.GetSection("SftpSettings").Get<SftpSettings>() ?? throw new InvalidOperationException("SFTP settings are not configured.");
        }

        public async Task UploadFileAsync(string fileName, string fileContent)
        {
            using (var client = new SftpClient(_sftpSettings.Host, _sftpSettings.Port, _sftpSettings.Username, _sftpSettings.Password))
            {
                try
                {
                    await client.ConnectAsync(CancellationToken.None);
                    
                    string remoteFilePath = Path.Combine(_sftpSettings.RemotePath, fileName).Replace("\\", "/");
                    string remoteDirectory = _sftpSettings.RemotePath.Replace("\\", "/");

                    if (!client.Exists(remoteDirectory))
                    {
                        client.CreateDirectory(remoteDirectory);
                    }

                    using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(fileContent)))
                    {
                        await Task.Run(() => client.UploadFile(stream, remoteFilePath, true));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to upload file '{FileName}' to SFTP server: {Message}", fileName, ex.Message);
                    throw; // Re-throw to allow Hangfire to catch and retry if configured
                }
                finally
                {
                    if (client.IsConnected)
                    {
                        client.Disconnect();
                    }
                }
            }
        }
    }

    public class SftpSettings
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RemotePath { get; set; } = string.Empty;
    }
}