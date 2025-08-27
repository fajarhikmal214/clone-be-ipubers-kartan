using be_ipubers_kartan.Dtos;
using be_ipubers_kartan.Models.Rekan;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace be_ipubers_kartan.Repositories
{
    public interface ICekStokRepo
    {
        Task<IEnumerable<Pkp>> GetPkpByKecamatan(string idKecamatan, string? idRetailer);
        Task<IEnumerable<StokKiosDto>> GetRetailerStock(string idKecamatan, string[] retailerIds, string[] productIds);
        Task<int> GetStokKiosByIdRetailerKodeProduk(string kodeProduk, string idRetailer, string idkecamatan);
        Task<List<CekStokByKecamatan>> GetStokKiosByIdRetailerKodeProdukNKecamatan(string kodeProduk, string idRetailer, IEnumerable<string> idkecamatanList);
    }

    public class StokKiosRepo : ICekStokRepo
    {
        private readonly string _connectionString;

        public StokKiosRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("RekanConnection") ?? throw new InvalidOperationException("Connection string 'RekanConnection' is not configured.");
        }

        public async Task<IEnumerable<Pkp>> GetPkpByKecamatan(string idKecamatan, string? idRetailer = null)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = @"
                SELECT DISTINCT KodeRetailer
                FROM Pkp
                WHERE 
                    IdKecamatan = @IdKecamatan
                    AND (@IdRetailer IS NULL OR KodeRetailer = @IdRetailer);
            ";

            var data = await connection.QueryAsync<Pkp>(query, new { IdKecamatan = idKecamatan, IdRetailer = idRetailer });
            return data;
        }

        public async Task<IEnumerable<StokKiosDto>> GetRetailerStock(string idKecamatan, string[] retailerIds, string[] productIds)
        {
            var connection = new SqlConnection(_connectionString);
            var query = @"
                WITH dataPkp AS (
                    SELECT  
                        p.KodeRetailer, 
                        pr.KodeProduk,
                        pr.NamaProduk,
                        'Kg' NamaSatuan, 
                        mk.IdInduk IdKecamatan,
                        COALESCE(SUM(pd.Qty), 0) AS Tebus
                    FROM PkpDetail pd
                    INNER JOIN Pkp p ON pd.IdPkp = p.Id
                    INNER JOIN ProdukRetailer pr ON pr.Id = pd.IdProdukRetailer AND pr.KodeProduk IN @ProductIds
                    INNER JOIN RetailerRoles rr ON rr.IdRetailer = p.KodeRetailer
                    INNER JOIN MasterKecamatan mk ON mk.Id = @IdKecamatan
                    WHERE 
                        p.Status = 'r' 
                        AND p.DocDate >= rr.TanggalStokAwal 
                        AND p.KodeRetailer IN @RetailerIds
                        AND pd.KodeProdukRMS IN @ProductIds
                        AND p.IdKecamatan = mk.Id
                    GROUP BY p.KodeRetailer, pr.KodeProduk, pr.NamaProduk, mk.idinduk
                ),

                dataSalur AS (
                    SELECT
                        p.IdRetailer,
                        pr.KodeProduk,
                        ma.IdKecamatanRekan AS IdKecamatan,
                        COALESCE(SUM(ppr.Qty), 0) AS Salur
                    FROM
                        Penjualan AS p
                    INNER JOIN PenjualanProdukRetailer AS ppr ON ppr.IdPenjualan = p.Id
                    INNER JOIN ProdukRetailer AS pr ON pr.Id = ppr.IdProdukRetailer
                    INNER JOIN _areas AS a ON a.sub_district_code = p.KodeDesa
                    INNER JOIN dbo_master.MappingArea AS ma ON ma.district_code = a.district_code
                    INNER JOIN RetailerRoles AS rr ON rr.IdRetailer = p.IdRetailer
                    WHERE
                        p.IdRetailer IN @RetailerIds
                        AND a.district_code = @IdKecamatan
                        AND pr.KodeProduk IN @ProductIds
                        AND p.JenisPenjualan IN (1, 4)
                        AND p.TanggalNota >= rr.TanggalStokAwal
                        AND ma.Tahun = YEAR(GETDATE())
                    GROUP BY
                        p.IdRetailer,
                        pr.KodeProduk,
                        ma.IdKecamatanRekan
                )

                SELECT
                    pkp.KodeProduk,
                    pkp.NamaProduk AS Produk,
                    pkp.NamaSatuan AS Satuan,
                    pkp.KodeRetailer AS KodeKios,
                    (pkp.Tebus - COALESCE(slr.Salur, 0)) AS Stok,
                    pkp.idkecamatan AS IdKecamatan,
                    mk.nama AS Kecamatan
                FROM
                    dataPkp AS pkp
                LEFT JOIN
                    dataSalur AS slr ON pkp.KodeProduk = slr.KodeProduk
                    AND pkp.idkecamatan = slr.IdKecamatan
                    AND pkp.KodeRetailer = slr.IdRetailer
                LEFT JOIN
                    MasterKecamatan AS mk ON pkp.idkecamatan = mk.id;
            ";

            var data = await connection.QueryAsync<StokKiosDto>(query, new
            {
                IdKecamatan = idKecamatan,
                ProductIds = productIds,
                RetailerIds = retailerIds
            });

            return data;
        }

        public async Task<int> GetStokKiosByIdRetailerKodeProduk (string kodeProduk, string idRetailer, string idkecamatan)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = @"
                 with dataPkp AS (SELECT pd.KodeProdukRMS KodeProduk, p.KodeRetailer, pr.NamaProduk, 'Kg' NamaSatuan, p1.Gambar, sum(pd.Qty) as Tebus, mk.IdInduk IdKecamatan FROM PkpDetail pd
                  INNER JOIN Pkp p ON pd.IdPkp = p.Id
                  inner join ProdukRetailer pr ON pd.IdProdukRetailer = pr.Id
                  INNER join Produk p1 on p1.KodeProduk = pr.KodeProduk
                  inner join RetailerRoles rr ON rr.IdRetailer = pr.IdRetailer
                  INNER join MasterKecamatan mk on mk.Id = p.IdKecamatan
                  WHERE p.Status='r' AND p.DocDate>=rr.TanggalStokAwal AND p.KodeRetailer=@idRetailer AND pd.KodeProdukRMS =@kodeProduk AND p.IdKecamatan = @idkecamatan 
                group BY pd.KodeProdukRMS, p.KodeRetailer, pr.NamaProduk, p1.Gambar, mk.idinduk ),
                dataSalur AS (
                  SELECT pr.KodeProduk, SUM(ppr.Qty) Salur, ma.IdKecamatanRekan FROM Penjualan p
                  INNER JOIN PenjualanProdukRetailer ppr ON p.Id = ppr.IdPenjualan
                  INNER JOIN ProdukRetailer pr ON ppr.IdProdukRetailer = pr.Id
                  INNER JOIN Retailer r ON p.IdRetailer = r.Code
                  inner join RetailerRoles rr ON r.Code = rr.IdRetailer
                  INNER JOIN _areas a ON A.sub_district_code = p.KodeDesa
                  inner JOIN dbo_master.MappingArea ma on ma.district_code = a.district_code AND year(p.TanggalNota)=ma.Tahun
                  WHERE p.IdRetailer = @idRetailer AND p.JenisPenjualan in (1,4) AND p.TanggalNota>=rr.TanggalStokAwal AND pr.KodeProduk = @kodeProduk AND ma.IdKecamatanRekan = @idkecamatan
                group BY pr.KodeProduk, ma.IdKecamatanRekan
                )
                SELECT 
                    dataPkp.Tebus - COALESCE(Salur,0) Stok
                FROM dataPkp
                left JOIN dataSalur ON datapkp.KodeProduk = dataSalur.KodeProduk AND datapkp.IdKecamatan = datasalur.IdKecamatanRekan
                left join MasterKecamatan mk ON mk.Id = IdKecamatan
            ";
            var stok = await connection.QuerySingleAsync<int>(query, new { kodeProduk, idRetailer, idkecamatan });
            return stok;
        }
        public async Task<List<CekStokByKecamatan>> GetStokKiosByIdRetailerKodeProdukNKecamatan(string kodeProduk, string idRetailer, IEnumerable<string> idkecamatanList)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = @"
                 with dataPkp AS (SELECT pd.KodeProdukRMS KodeProduk, p.KodeRetailer, pr.NamaProduk, 'Kg' NamaSatuan, p1.Gambar, sum(pd.Qty) as Tebus, mk.IdInduk IdKecamatan, mk.Nama NamaKecamatan FROM PkpDetail pd
                  INNER JOIN Pkp p ON pd.IdPkp = p.Id
                  inner join ProdukRetailer pr ON pd.IdProdukRetailer = pr.Id
                  INNER join Produk p1 on p1.KodeProduk = pr.KodeProduk
                  inner join RetailerRoles rr ON rr.IdRetailer = pr.IdRetailer
                  INNER join MasterKecamatan mk on mk.Id = p.IdKecamatan
                  WHERE p.Status='r' AND p.DocDate>=rr.TanggalStokAwal AND p.KodeRetailer=@idRetailer AND pd.KodeProdukRMS =@kodeProduk AND p.IdKecamatan IN @idkecamatanList 
                group BY pd.KodeProdukRMS, p.KodeRetailer, pr.NamaProduk, p1.Gambar, mk.idinduk, mk.Nama ),
                dataSalur AS (
                  SELECT pr.KodeProduk, SUM(ppr.Qty) Salur, ma.IdKecamatanRekan FROM Penjualan p
                  INNER JOIN PenjualanProdukRetailer ppr ON p.Id = ppr.IdPenjualan
                  INNER JOIN ProdukRetailer pr ON ppr.IdProdukRetailer = pr.Id
                  INNER JOIN Retailer r ON p.IdRetailer = r.Code
                  inner join RetailerRoles rr ON r.Code = rr.IdRetailer
                  INNER JOIN _areas a ON A.sub_district_code = p.KodeDesa
                  inner JOIN dbo_master.MappingArea ma on ma.district_code = a.district_code AND year(p.TanggalNota)=ma.Tahun
                  WHERE p.IdRetailer = @idRetailer AND p.JenisPenjualan in (1,4) AND p.TanggalNota>=rr.TanggalStokAwal AND pr.KodeProduk = @kodeProduk AND ma.IdKecamatanRekan IN @idkecamatanList
                group BY pr.KodeProduk, ma.IdKecamatanRekan
                )
                SELECT 
                    dataPkp.idkecamatan AS IdKecamatan,
                    dataPkp.NamaKecamatan AS NamaKecamatan,
                    dataPkp.Tebus - COALESCE(Salur,0) Stok
                FROM dataPkp
                left JOIN dataSalur ON datapkp.KodeProduk = dataSalur.KodeProduk AND datapkp.IdKecamatan = datasalur.IdKecamatanRekan
                left join MasterKecamatan mk ON mk.Id = IdKecamatan
            ";

            var stok = await connection.QueryAsync<CekStokByKecamatan>(query, new { kodeProduk, idRetailer, idkecamatanList });
            return stok.ToList();
        }
    }
}
