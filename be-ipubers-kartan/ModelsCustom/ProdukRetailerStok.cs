using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace be_ipubers_kartan.ModelsCustom
{
    public class ProdukRetailerStok
    {
        public enum OpsiTipeStok
        {
            PENYESUAIAN_PENAMBAHAN = 1,
            PENAMBAHAN_RECEIPT = 2,
            PENGURANGAN_PENJUALAN = 3,
            PRODUK_BARU = 4,
            PEMBATALAN_PENJUALAN = 5,
            PENAMBAHAN_PO = 6,
            PENYESUAIAN_PENGURANGAN = 7
        }
        public int Id { get; set; }
        [JsonIgnore]
        public ProdukRetailer ProdukRetailer { get; set; }
        public DateTime TanggalTransaksi { get; set; }
        public double StokAwal { get; set; }
        [Required(ErrorMessage = "JumlahStok wajib diisi dengan angka")]
        public Double JumlahStok { get; set; }
        public double StokAkhir { get; set; }
        public OpsiTipeStok TipeStok { get; set; }
        public string Deskripsi { get; set; }
        public LogInfo LogInfo { get; set; }
    }
}
