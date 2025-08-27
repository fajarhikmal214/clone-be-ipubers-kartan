using System.Text;
using be_ipubers_kartan.Dtos;
using be_ipubers_kartan.Services;
using Dapper;
using Microsoft.Data.SqlClient;
using Serilog;

namespace be_ipubers_kartan.Jobs
{
    public class RekonTransaksiJob
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly SftpUploaderService _sftpUploaderService;
        private readonly int _chunkSize;

        public RekonTransaksiJob(IConfiguration configuration, SftpUploaderService sftpUploaderService)
        {
            _configuration = configuration;
            _sftpUploaderService = sftpUploaderService;

            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
            _chunkSize = _configuration.GetValue("HangfireSettings:RekonTransaksiChunkSize", 10000);
        }

        public async Task RekonTransaksi()
        {
            using var connection = new SqlConnection(_connectionString);
            DateTime transactionDate = DateTime.Today.AddDays(-1);

            StringBuilder csvContentBuilder = new();
            csvContentBuilder.AppendLine("Refnum,TanggalTransaksi,NIK,MID");

            bool isAbleToNextRows = true;
            int currentOffset = 0;
            int totalRecordsProcessed = 0;

            string query = @"
                SELECT
                    NoReferensi AS 'Refnum',
                    TanggalNota AS 'TanggalTransaksi',
                    NoHp AS 'NIK',
                    KodePelanggan AS 'MID'
                FROM
                    Penjualan
                WHERE
                    source = 27
                    AND CONVERT(DATE, TanggalNota) = @TransactionDate
                ORDER BY
                    TanggalNota, NoReferensi ASC
                OFFSET @Offset ROWS
                FETCH NEXT @ChunkSize ROWS ONLY";

            do
            {
                int recordsFetchedInThisChunk = 0;
                var data = await connection.QueryAsync<RekonTransaksiDto>(query, new
                {
                    TransactionDate = transactionDate.Date,
                    Offset = currentOffset,
                    ChunkSize = _chunkSize
                });

                var transactions = data.ToList();
                foreach (var transaction in transactions)
                {
                    csvContentBuilder.AppendLine(
                        $"{QuoteCsvField(transaction.Refnum?.ToString())}," +
                        $"{QuoteCsvField(transaction.TanggalTransaksi?.ToString())}," +
                        $"{QuoteCsvField(transaction.NIK?.ToString())}," +
                        $"{QuoteCsvField(transaction.MID?.ToString())}"
                    );

                    recordsFetchedInThisChunk++;
                }

                isAbleToNextRows = recordsFetchedInThisChunk > 0;
                currentOffset += recordsFetchedInThisChunk;
                totalRecordsProcessed += recordsFetchedInThisChunk;

            } while (isAbleToNextRows);

            // Upload file to SFTP Server
            await UploadChunk(csvContentBuilder.ToString(), transactionDate);

            Log.Information("RekonTransaksiJob: Executing recurring RekonTransaksiJob task at {CurrentTime} with total {TotalRecord} records", DateTime.Now, totalRecordsProcessed);
        }

        private async Task UploadChunk(string content, DateTime date)
        {
            string fileName = $"rekon_{date:yyyyMMdd}.csv";
            await _sftpUploaderService.UploadFileAsync(fileName, content);
        }

        private string QuoteCsvField(string? field)
        {
            if (field == null)
            {
                return "";
            }

            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n") || field.Contains("\r"))
            {
                return $"\"{field.Replace("\"", "\"\"")}\"";
            }

            return field;
        }
    }
}