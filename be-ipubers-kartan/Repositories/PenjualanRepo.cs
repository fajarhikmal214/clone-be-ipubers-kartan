using be_ipubers_kartan.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace be_ipubers_kartan.Repositories
{
    public interface IPenjualanRepo
    {
        Task<int> InsertPenjualanIPubers(Models.Penjualan penjualan, SqlConnection connIpubers, SqlTransaction transIpubers);
        Task<int> InsertPenjualanRekan(Models.Penjualan penjualan, SqlConnection connRekan, SqlTransaction transRekan);
    }
    public class PenjualanRepo : IPenjualanRepo
    {
        private readonly RMSContext _context;

        public PenjualanRepo(RMSContext context, IConfiguration configuration)
        {
            _context = context;
        }
        public async Task<int> InsertPenjualanIPubers(Models.Penjualan penjualan, SqlConnection connIpubers, SqlTransaction transIpubers)
        {
            try
            {
                string Query = @"insert into penjualan (NoNota, IdRetailer, IdPetani, KodePelanggan, Nama, NoHp, TanggalNota, TanggalJatuhTempo,
                                    FotoKTPPembeli, FotoKTPPembeliLokasi,
                                    FotoKTPPembeliWaktu,
                                    FotoKTPPemilik, FotoKTPPemilikLokasi, FotoKTPPemilikWaktu,
                                    TandaTangan, JenisPenjualan, Status, NoReferensi, Catatan, CreatedAt, CreatedBy, IdBag, PoktanId,
                                    KodeDesa, Source, FotoKtpPerwakilan, SwaFotoPerwakilan, NamaPerwakilan, BatchId, SuratPernyataan,
                                    BuktiPenyaluranPetani,BuktiKtpBeda,NikPerwakilan,KomoditiId, NamaPoktan, idbilling, SyncRekanAt, SyncRekanStatus,SyncRekanMessage,
                                    SyncAlokasiAt, SyncAlokasiStatus, SyncAlokasiMessage)
                             OUTPUT INSERTED.Id
                             values (@NoNota, @IdRetailer, @IdPetani, @KodePelanggan, @Nama, @NoHp, @TanggalNota, @TanggalJatuhTempo,
                                    @FotoKTPPembeli, @FotoKTPPembeliLokasi,
                                    @FotoKTPPembeliWaktu,
                                    @FotoKTPPemilik, @FotoKTPPemilikLokasi, @FotoKTPPemilikWaktu, @TandaTangan,
                                    @JenisPenjualan, @Status, @NoReferensi, @Catatan, @CreatedAt, @CreatedBy, @IdBag, @poktanid, @kodedesa, @Source,
                                    @FotoKtpPerwakilan, @SwaFotoPerwakilan, @NamaPerwakilan, @BatchId, @SuratPernyataan, @BuktiPenyaluranPetani,
                                    @BuktiKtpBeda,@NikPerwakilan,@IdKomoditas, @NamaPoktan, @IdBilling, @SyncRekanAt, @SyncRekanStatus, @SyncRekanMessage,
                                    @SyncAlokasiAt, @SyncAlokasiStatus, @SyncAlokasiMessage)";

                var result = await connIpubers.QuerySingleAsync<int>(Query, new
                {
                    NoNota = penjualan.NoNota,
                    IdRetailer = penjualan.IdRetailer,
                    IdPetani = penjualan.IdPetani,
                    KodePelanggan = penjualan.KodePelanggan,
                    Nama = penjualan.Nama,
                    NoHp = penjualan.NoHp,
                    TanggalNota = penjualan.TanggalNota,
                    TanggalJatuhTempo = penjualan.TanggalJatuhTempo,
                    FotoKTPPembeli = penjualan.FotoKtppembeli,
                    FotoKTPPembeliLokasi = penjualan.FotoKtppembeliLokasi,
                    FotoKTPPembeliWaktu = penjualan.FotoKtppembeliWaktu,
                    FotoKTPPemilik = penjualan.FotoKtppemilik,
                    FotoKTPPemilikLokasi = penjualan.FotoKtppembeliLokasi,
                    FotoKTPPemilikWaktu = penjualan.FotoKtppemilikWaktu,
                    TandaTangan = penjualan.TandaTangan,
                    JenisPenjualan = penjualan.JenisPenjualan,
                    Status = penjualan.Status,
                    NoReferensi = penjualan.NoReferensi,
                    Catatan = penjualan.Catatan,
                    CreatedBy = penjualan.CreatedBy,
                    CreatedAt = penjualan.CreatedAt,
                    IdBag = penjualan.IdBag,
                    PoktanId = penjualan.PoktanId,
                    KodeDesa = penjualan.KodeDesa,
                    Source = penjualan.Source,
                    FotoKtpPerwakilan = penjualan.FotoKtpPerwakilan,
                    SwaFotoPerwakilan = penjualan.SwaFotoPerwakilan,
                    NamaPerwakilan = penjualan.NamaPerwakilan,
                    BatchId = penjualan.BatchId,
                    SuratPernyataan = penjualan.SuratPernyataan,
                    BuktiPenyaluranPetani = penjualan.BuktiPenyaluranPetani,
                    BuktiKtpBeda = penjualan.BuktiKtpBeda,
                    NikPerwakilan = penjualan.NikPerwakilan,
                    IdKomoditas = penjualan.KomoditiId,
                    NamaPoktan = penjualan.NamaPoktan,
                    SyncRekanAt = DateTime.Now,
                    SyncRekanStatus = 1,
                    SyncRekanMessage = "Transaksi Kartan BRI",
                    SyncAlokasiAt = DateTime.Now,
                    SyncAlokasiStatus = 4,
                    SyncAlokasiMessage = "Transaksi Kartan BRI",
                    IdBilling = penjualan.IdBilling
                }, transaction: (SqlTransaction)transIpubers);

                return result;
            }
            catch(Exception ex)
            {
                throw new Exception($"Error Penjualan Ipubers - {ex.Message}");
            }
        }
        public async Task<int> InsertPenjualanRekan(Models.Penjualan penjualan, SqlConnection connRekan, SqlTransaction transRekan)
        {
            try
            {
                string Query = @"insert into penjualan (NoNota, IdRetailer, IdPetani, KodePelanggan, Nama, NoHp, TanggalNota, TanggalJatuhTempo,
        					   FotoKTPPembeli, FotoKTPPembeliLokasi,
        					   FotoKTPPembeliWaktu,
        					   FotoKTPPemilik, FotoKTPPemilikLokasi, FotoKTPPemilikWaktu,
        					   TandaTangan, JenisPenjualan, Status, NoReferensi, Catatan, CreatedAt, CreatedBy, IdBag, PoktanId,
        					   KodeDesa, Source, FotoKtpPerwakilan, SwaFotoPerwakilan, NamaPerwakilan, BatchId, SuratPernyataan,
        					   BuktiPenyaluranPetani,BuktiKtpBeda,NikPerwakilan,KomoditiId)
                        OUTPUT INSERTED.Id
                        values (@NoNota, @IdRetailer, @IdPetani, @KodePelanggan, @Nama, @NoHp, @TanggalNota, @TanggalJatuhTempo,
        		                @FotoKTPPembeli, @FotoKTPPembeliLokasi,
        		                @FotoKTPPembeliWaktu,
        		                @FotoKTPPemilik, @FotoKTPPemilikLokasi, @FotoKTPPemilikWaktu, @TandaTangan,
        		                @JenisPenjualan, @Status, @NoReferensi, @Catatan, @CreatedAt, @CreatedBy, @IdBag, @poktanid, @kodedesa, @Source,
        		                @FotoKtpPerwakilan, @SwaFotoPerwakilan, @NamaPerwakilan, @BatchId, @SuratPernyataan, @BuktiPenyaluranPetani,
        		                @BuktiKtpBeda,@NikPerwakilan,@IdKomoditas)";

                var result = await connRekan.QuerySingleAsync<int>(Query, new
                {
                    NoNota = penjualan.NoNota,
                    IdRetailer = penjualan.IdRetailer,
                    IdPetani = penjualan.IdPetani,
                    KodePelanggan = penjualan.KodePelanggan,
                    Nama = penjualan.Nama,
                    NoHp = penjualan.NoHp,
                    TanggalNota = penjualan.TanggalNota,
                    TanggalJatuhTempo = penjualan.TanggalJatuhTempo,
                    FotoKTPPembeli = penjualan.FotoKtppembeli,
                    FotoKTPPembeliLokasi = penjualan.FotoKtppembeliLokasi,
                    FotoKTPPembeliWaktu = penjualan.FotoKtppembeliWaktu,
                    FotoKTPPemilik = penjualan.FotoKtppemilik,
                    FotoKTPPemilikLokasi = penjualan.FotoKtppembeliLokasi,
                    FotoKTPPemilikWaktu = penjualan.FotoKtppemilikWaktu,
                    TandaTangan = penjualan.TandaTangan,
                    JenisPenjualan = penjualan.JenisPenjualan,
                    Status = penjualan.Status,
                    NoReferensi = penjualan.NoReferensi,
                    Catatan = penjualan.Catatan,
                    CreatedBy = penjualan.CreatedBy,
                    CreatedAt = penjualan.CreatedAt,
                    IdBag = penjualan.IdBag,
                    PoktanId = penjualan.PoktanId,
                    KodeDesa = penjualan.KodeDesa,
                    Source = penjualan.Source,
                    FotoKtpPerwakilan = penjualan.FotoKtpPerwakilan,
                    SwaFotoPerwakilan = penjualan.SwaFotoPerwakilan,
                    NamaPerwakilan = penjualan.NamaPerwakilan,
                    BatchId = penjualan.BatchId,
                    SuratPernyataan = penjualan.SuratPernyataan,
                    BuktiPenyaluranPetani = penjualan.BuktiPenyaluranPetani,
                    BuktiKtpBeda = penjualan.BuktiKtpBeda,
                    NikPerwakilan = penjualan.NikPerwakilan,
                    IdKomoditas = penjualan.KomoditiId
                }, transaction: (SqlTransaction)transRekan);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Penjualan Rekan - {ex.Message}");
            }
        }
    }
}
