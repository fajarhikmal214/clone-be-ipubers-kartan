using be_ipubers_kartan.Dtos;
using be_ipubers_kartan.Interface;
using be_ipubers_kartan.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace be_ipubers_kartan.Services
{
    public interface ITransactionService
    {
        Task<List<CekStokByKecamatan>> GetStokRekanByKodeProdukKodeKios(string kodeProduk, string idRetailer, IEnumerable<string> idkecamatanList);
        Task<int> GetStokRekanByRefNum(string refnum);
        Task<Models.Petani> GetDataPetaniIpubers(string createdby, Models.Petani petani);
        Task<Models.Rekan.Petani> GetDatapetaniRekan(string createdby, Models.Rekan.Petani petani);
        Task<string> GetKodeProdukFromIdPenjualan(string idPenjualan);
        Task InsertIntoIpubers(Models.Penjualan penjualan, SqlConnection connIpubers, SqlTransaction transIpubers);
        Task InsertIntoRekan(Models.Penjualan penjualan, SqlConnection connRekan, SqlTransaction transRekan);

    }

    public class TransactionService : ITransactionService
    {
        private readonly ICekStokRepo _stokKiosRepo;
        private readonly IRetailerRepo _retailerRepo;
        private readonly ITransaksiKartanService _transaksiKartanService;
        private readonly IPetaniService _petaniService;
        private readonly IPenjualanRepo _penjualanRepo;
        private readonly PenjualanProdukRetailerRepo _penjualanProdukRetailerRepo;
        private readonly IPembayaran _pembayaranRepo;
        private readonly IProdukRetailerService _produkRetailerService;
        private readonly IProdukRetailerStokRekanService _produkRetailerStokRekanService;
        private readonly IProdukRetailerStokKecamatanService _produkRetailerStokKecamatanService;

        public TransactionService(ICekStokRepo stokKiosRepo, IRetailerRepo retailerRepo, ITransaksiKartanService transaksiKartanService, IPetaniService petaniService, IPenjualanRepo penjualanRepo, IPembayaran pembayaranRepo, PenjualanProdukRetailerRepo penjualanProdukRetailerRepo, IProdukRetailerService produkRetailerService, IProdukRetailerStokRekanService produkRetailerStokRekanService, IProdukRetailerStokKecamatanService produkRetailerStokKecamatanService)
        {
            _stokKiosRepo = stokKiosRepo;
            _retailerRepo = retailerRepo;
            _transaksiKartanService = transaksiKartanService;
            _petaniService = petaniService;
            _penjualanRepo = penjualanRepo;
            _pembayaranRepo = pembayaranRepo;
            _penjualanProdukRetailerRepo = penjualanProdukRetailerRepo;
            _produkRetailerService = produkRetailerService;
            _produkRetailerStokRekanService = produkRetailerStokRekanService;
            _produkRetailerStokKecamatanService = produkRetailerStokKecamatanService;
        }
        public async Task<List<CekStokByKecamatan>> GetStokRekanByKodeProdukKodeKios(string kodeProduk, string idRetailer, IEnumerable<string> idkecamatanList)
        {
            var result = await _stokKiosRepo.GetStokKiosByIdRetailerKodeProdukNKecamatan(kodeProduk, idRetailer, idkecamatanList);

            return result;
        }
        public async Task<int> GetStokRekanByRefNum(string refnum)
        {
            CekStokByRefNum getData = await _retailerRepo.getRetailerByRefNum(refnum);

            var result = await _stokKiosRepo.GetStokKiosByIdRetailerKodeProduk(getData.KodeProduk, getData.IdRetailer, getData.IdKecamatan);

            return result;
        }
        public async Task<Models.Petani> GetDataPetaniIpubers(string createdby, Models.Petani petaniTemp)
        {
            // get data or create if not exists
            Models.Petani petani = await _petaniService.InsertAvailableNIKIpubers(petaniTemp, createdby);
            return petani;
        }
        public async Task<Models.Rekan.Petani> GetDatapetaniRekan(string createdby, Models.Rekan.Petani petaniTemp)
        {
            // get data or create if not exists
            Models.Rekan.Petani petani = await _petaniService.InsertAvailableNIKRekan(petaniTemp, createdby);
            return petani;
        }
        public async Task<string> GetKodeProdukFromIdPenjualan(string idPenjualan)
        {
            string kodeProduk = await _penjualanProdukRetailerRepo.GetKodeProduk(idPenjualan);
            return kodeProduk;
        }

        public async Task InsertIntoIpubers(Models.Penjualan penjualan, SqlConnection connIpubers, SqlTransaction transIpubers)
        {
            //Insert Penjualan
            var result = await _penjualanRepo.InsertPenjualanIPubers(penjualan, connIpubers, transIpubers);
            penjualan.Id = result;

            //Insert Penjualan Produk Retailer
            var dataPenjualanProdukRetailer = penjualan.PenjualanProdukRetailers.FirstOrDefault();
            if (dataPenjualanProdukRetailer != null)
            {
                dataPenjualanProdukRetailer.IdPenjualan = result;
                await _penjualanProdukRetailerRepo.InsertData((SqlTransaction)transIpubers, dataPenjualanProdukRetailer);
            }

            //insert pembayaran
            var pembayaran = penjualan.Pembayarans.FirstOrDefault();
            if (pembayaran != null)
            {
                pembayaran.IdPenjualan = result;
                pembayaran.NoPembayaran = penjualan.NoNota;
                pembayaran.TanggalPembayaran = penjualan.TanggalNota;
                pembayaran.IdPenjualanNavigation = new Models.Penjualan { Id = result };
                pembayaran.CreatedAt = DateTime.Now;
                pembayaran.CreatedBy = penjualan.CreatedBy;
                pembayaran.Catatan = "Transaksi Kartan BRI";
                pembayaran.JenisPembayaran = "1";
                pembayaran.Status = "1";

                await _pembayaranRepo.InsertData(pembayaran, connIpubers, (SqlTransaction)transIpubers);
            }
        }

        public async Task InsertIntoRekan(Models.Penjualan penjualan, SqlConnection connRekan, SqlTransaction transRekan)
        {
            //Insert Penjualan
            var result = await _penjualanRepo.InsertPenjualanRekan(penjualan, connRekan, transRekan);
            penjualan.Id = result;

            //Insert Penjualan Produk Retailer
            var dataPenjualanProdukRetailer = penjualan.PenjualanProdukRetailers.LastOrDefault();
            if (dataPenjualanProdukRetailer != null)
            {
                var rekanItem = new Models.Rekan.PenjualanProdukRetailer
                {
                    Id = dataPenjualanProdukRetailer.Id,
                    IdPenjualan = result,
                    IdProdukRetailer = dataPenjualanProdukRetailer.IdProdukRetailer,
                    HargaJual = dataPenjualanProdukRetailer.HargaJual,
                    HargaBeli = dataPenjualanProdukRetailer.HargaBeli,
                    Qty = dataPenjualanProdukRetailer.Qty,
                    Catatan = dataPenjualanProdukRetailer.Catatan,
                    LevelHargaJual = dataPenjualanProdukRetailer.LevelHargaJual

                };
                await _penjualanProdukRetailerRepo.InsertDataRekan(connRekan, (SqlTransaction)transRekan, rekanItem);
            }

            //insert pembayaran
            if (penjualan.Pembayarans is not null)
            {
                var penjualanPembayaran = penjualan.Pembayarans.FirstOrDefault();
                if (penjualanPembayaran == null)
                    throw new ArgumentNullException(nameof(penjualan.Pembayarans), "Pembayaran cannot be null");
 
                penjualanPembayaran.Catatan = penjualanPembayaran.Catatan == null? "Transaksi Kartan BRI" : penjualanPembayaran.Catatan;
                penjualanPembayaran.JenisPembayaran = "1";
                penjualanPembayaran.Status = "1";

                Models.Rekan.Pembayaran rekanPembayarans = new Models.Rekan.Pembayaran
                {
                    IdPenjualan = result,
                    NoPembayaran = penjualan.NoNota,
                    TanggalPembayaran = penjualan.TanggalNota,
                    JenisPembayaran = penjualanPembayaran.JenisPembayaran,
                    KartuPembayaran = penjualanPembayaran.KartuPembayaran,
                    Jumlah = penjualanPembayaran.Jumlah,
                    Catatan = penjualanPembayaran.Catatan,
                    CreatedAt = DateTime.Now,
                    CreatedBy = penjualan.CreatedBy,
                    IdPenjualanNavigation = new Models.Rekan.Penjualan { Id = result }
                };

                await _pembayaranRepo.InsertDataRekan(rekanPembayarans, connRekan, (SqlTransaction)transRekan);
            }

            var stokItem = penjualan.PenjualanProdukRetailers.LastOrDefault()?.IdProdukRetailerNavigation?.ProdukRetailerStoks.FirstOrDefault();
            var produkRetailer = penjualan.PenjualanProdukRetailers.LastOrDefault().IdProdukRetailerNavigation;

            var queryProduk = @"SELECT TOP 1 Stok FROM ProdukRetailer WHERE Id = @Id";
            var produkRetailerStok = await connRekan.QueryFirstOrDefaultAsync<double>(queryProduk, new { Id = produkRetailer.Id }, transaction: (SqlTransaction)transRekan);

            if (penjualan.Status == "2" && produkRetailerStok < (stokItem.JumlahStok * -1))
            {
                throw new Exception($"Stok produk {produkRetailer.NamaProduk} tidak mencukupi");
            }

            stokItem.TglTransaksi = penjualan.TanggalNota;
            stokItem.StokAwal = produkRetailerStok;
            stokItem.KodeTransaksiStok = penjualan.Id.ToString();
            stokItem.StokAkhir = penjualan.PenjualanProdukRetailers.LastOrDefault()?.IdProdukRetailerNavigation?.Stok ?? 0;
            stokItem.Deskripsi = $"Penjualan produk - Id:{result} - NoTransaksi:{penjualan.NoNota}";
            stokItem.IdProdukRetailer = produkRetailer.Id;

            // Update Stok Produk Retailer
            await UpdateStokProdukRetailerRekan(transRekan, produkRetailer.Id, stokItem.StokAkhir);

            // Insert Produk Retailer Stok
            await InsertProdukRetailerStokRekan(connRekan, transRekan, stokItem, penjualan, produkRetailer.KodeProduk);

            // Update Stok Kecamatan
            await UpdateStokKecamatan(connRekan, transRekan, produkRetailer.Id, penjualan.KodeDesa, stokItem.JumlahStok);
        }

        public async Task UpdateStokProdukRetailerRekan(SqlTransaction transRekan, int idProdukRetailer, double stok)
        {
            var stokprodukRetailer = new Models.Rekan.ProdukRetailer
            {
                Id = idProdukRetailer,
                Stok = stok
            };

            await _produkRetailerService.UpdateStokAsyncToRekan(stokprodukRetailer, (SqlTransaction)transRekan);
        }

        public async Task InsertProdukRetailerStokRekan(SqlConnection connRekan, SqlTransaction transRekan, Models.ProdukRetailerStok stokItem, Models.Penjualan penjualan, string kodeProduk)
        {
            var stokItemRekan = new Models.Rekan.ProdukRetailerStok
            {
                IdProdukRetailer = stokItem.IdProdukRetailer,
                TglTransaksi = stokItem.TglTransaksi,
                KodeTransaksiStok = stokItem.KodeTransaksiStok,
                StokAwal = stokItem.StokAwal,
                JumlahStok = stokItem.JumlahStok,
                StokAkhir = stokItem.StokAkhir,
                TipeStok = penjualan.Status == "2" ? "13" : "14",
                Deskripsi = stokItem.Deskripsi,
                CreatedBy = penjualan.CreatedBy,
            };

            var produkRetailerUpdate = penjualan.PenjualanProdukRetailers.LastOrDefault(x => x.IdProdukRetailerNavigation.KodeProduk == kodeProduk);
            
            produkRetailerUpdate.IdPenjualan = penjualan.Id;
            produkRetailerUpdate.IdProdukRetailerNavigation.Stok = stokItem.StokAkhir;

            await _produkRetailerStokRekanService.UpdateStokAsync(stokItemRekan, connRekan, transRekan);
        }

        public async Task UpdateStokKecamatan(SqlConnection connRekan, SqlTransaction transRekan, int idProdukRetailer, string kodeDesa, double jumlahStok)
        {
            var kodeDesaParam = new SqlParameter("@KodeDesa", kodeDesa);

            var queryKecamatan = @"
                    SELECT ma.IdKecamatanRekan as Value
                    FROM _areas a
                    INNER JOIN dbo_master.MappingArea ma ON ma.district_code = a.district_code AND ma.Tahun = YEAR(GETDATE())
                    WHERE a.sub_district_code = @KodeDesa";

            var idKecamatan = await connRekan.QueryFirstOrDefaultAsync<string>(
                queryKecamatan,
                new { KodeDesa = kodeDesa },
                transaction: (SqlTransaction)transRekan);

            if (string.IsNullOrEmpty(idKecamatan))
            {
                throw new Exception($"Kode Desa {kodeDesa} tidak ditemukan");
            }

            await _produkRetailerStokKecamatanService.UpdateStokAsync(connRekan, (SqlTransaction)transRekan, jumlahStok, idProdukRetailer, idKecamatan);
        }
    }
}
