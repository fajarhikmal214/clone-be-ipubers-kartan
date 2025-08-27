using be_ipubers_kartan.Dtos;
using be_ipubers_kartan.Services;
using Dapper;
using Microsoft.Data.SqlClient;
using Serilog;
using System.Text;

namespace be_ipubers_kartan.Jobs
{
    public class LatestDataStokJob
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly SftpUploaderService _sftpUploaderService;
        private readonly int _chunkSize;

        public LatestDataStokJob(IConfiguration configuration, SftpUploaderService sftpUploaderService)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _sftpUploaderService = sftpUploaderService ?? throw new ArgumentNullException(nameof(sftpUploaderService));
            _connectionString = _configuration.GetConnectionString("RekanConnection")
                ?? throw new InvalidOperationException("Connection string 'RekanConnection' is not configured.");

            _chunkSize = _configuration.GetValue("HangfireSettings:LatestStokKiosChunkSize", 5000);

        }

        public async Task LatestDataStok()
        {
            using var connection = new SqlConnection(_connectionString);
            DateTime transactionDate = DateTime.Today.AddDays(-1);
            DateTime cutoffTransactionDate = DateTime.Today;

            StringBuilder csvContentBuilder = new();
            csvContentBuilder.AppendLine("KodeKios,KodeKecamatan,Urea,NPK,NPKFK,ORGR,ASZA");

            string query = @"
                WITH dataPkp AS (
                    SELECT 
                        pd.KodeProdukRMS AS KodeProduk,
                        p.KodeRetailer,
                        mk.IdInduk AS IdKecamatan,
                        SUM(pd.Qty) AS Tebus
                    FROM PkpDetail pd
                    INNER JOIN Pkp p ON pd.IdPkp = p.Id
                    INNER JOIN ProdukRetailer pr ON pd.IdProdukRetailer = pr.Id
                    INNER JOIN RetailerRoles rr ON rr.IdRetailer = pr.IdRetailer
                    INNER JOIN MasterKecamatan mk ON mk.Id = p.IdKecamatan
                    WHERE 
                        p.Status = 'r' 
                        AND p.DocDate >= rr.TanggalStokAwal 
                        AND pd.KodeProdukRMS IN ('UN46', 'NPKP', 'NPKFK', 'ORGR', 'ASZA')
                        AND p.ReceivedDate < @CutoffTransactionDate
                    GROUP BY 
                        pd.KodeProdukRMS, 
                        p.KodeRetailer, 
                        mk.IdInduk
                ),
                dataSalurAgg AS (
                    SELECT 
                        pr.KodeProduk,
                        p.IdRetailer,
                        ma.IdKecamatanRekan,
                        SUM(ppr.Qty) AS TotalSalur
                    FROM Penjualan p
                    INNER JOIN PenjualanProdukRetailer ppr ON p.Id = ppr.IdPenjualan
                    INNER JOIN ProdukRetailer pr ON ppr.IdProdukRetailer = pr.Id
                    INNER JOIN Retailer r ON p.IdRetailer = r.Code
                    INNER JOIN RetailerRoles rr ON r.Code = rr.IdRetailer
                    INNER JOIN _areas a ON a.sub_district_code = p.KodeDesa
                    INNER JOIN dbo_master.MappingArea ma ON ma.district_code = a.district_code 
                        AND YEAR(p.TanggalNota) = ma.Tahun
                    WHERE 
                        p.JenisPenjualan IN (1,4) 
                        AND p.TanggalNota >= rr.TanggalStokAwal 
                        AND pr.KodeProduk IN ('UN46', 'NPKP', 'NPKFK', 'ORGR', 'ASZA')
                        AND p.TanggalNota < @CutoffTransactionDate
                    GROUP BY 
                        pr.KodeProduk, 
                        p.IdRetailer,
                        ma.IdKecamatanRekan
                )
                SELECT 
                    dp.KodeRetailer AS KodeKios,
                    dp.IdKecamatan AS KodeKecamatan,
                    SUM(CASE WHEN dp.KodeProduk = 'UN46' THEN dp.Tebus - COALESCE(ds.TotalSalur, 0) ELSE 0 END) AS Urea,
                    SUM(CASE WHEN dp.KodeProduk = 'NPKP' THEN dp.Tebus - COALESCE(ds.TotalSalur, 0) ELSE 0 END) AS NPK,
                    SUM(CASE WHEN dp.KodeProduk = 'NPKFK' THEN dp.Tebus - COALESCE(ds.TotalSalur, 0) ELSE 0 END) AS NPKFK,
                    SUM(CASE WHEN dp.KodeProduk = 'ORGR' THEN dp.Tebus - COALESCE(ds.TotalSalur, 0) ELSE 0 END) AS ORGR,
                    SUM(CASE WHEN dp.KodeProduk = 'ASZA' THEN dp.Tebus - COALESCE(ds.TotalSalur, 0) ELSE 0 END) AS ASZA
                FROM dataPkp dp
                LEFT JOIN dataSalurAgg ds 
                    ON dp.KodeProduk = ds.KodeProduk 
                    AND dp.KodeRetailer = ds.IdRetailer 
                    AND dp.IdKecamatan = ds.IdKecamatanRekan
                GROUP BY 
                    dp.KodeRetailer, 
                    dp.IdKecamatan
                ORDER BY 
                    dp.IdKecamatan,
                    dp.KodeRetailer;
            ";

            var data = await connection.QueryAsync<LatestsStokDTO>(query, new { CutoffTransactionDate = cutoffTransactionDate });

            var stocks = data.ToList();
            foreach (var stockList in stocks)
            {
                csvContentBuilder.AppendLine(
                    $"{QuoteCsvField(stockList.KodeKios?.ToString())}," +
                    $"{QuoteCsvField(stockList.KodeKecamatan?.ToString())}," +
                    $"{QuoteCsvField(stockList.Urea.ToString())}," +
                    $"{QuoteCsvField(stockList.NPK.ToString())}," +
                    $"{QuoteCsvField(stockList.NPKFK.ToString())}," +
                    $"{QuoteCsvField(stockList.ORGR.ToString())}," +
                    $"{QuoteCsvField(stockList.ASZA.ToString())}"
                );
            }

            // Upload file to SFTP Server
            await UploadChunk(csvContentBuilder.ToString(), transactionDate);

            Log.Information("LatestDataStokJob: LatestDataStok executed at {CurrentTime}", DateTime.Now);
        }
        private async Task UploadChunk(string content, DateTime date)
        {
            string fileName = $"stok_{date:yyyyMMdd}.csv";
            await _sftpUploaderService.UploadFileAsync(fileName, content);
        }

        private string QuoteCsvField(string? field)
        {
            string? value = field?.ToString();

            if (string.IsNullOrEmpty(value))
            {
                return "";
            }

            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n") || value.Contains("\r"))
            {
                return $"\"{value.Replace("\"", "\"\"")}\"";
            }

            return value;
        }
    }
}