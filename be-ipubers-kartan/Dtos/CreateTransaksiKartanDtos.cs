using be_ipubers_kartan.Models.ViewModels;

namespace be_ipubers_kartan.Dtos
{
    public class CreateTransaksiKartanDtos : VMTransaksi
    {
        public required string ReferenceNumber { get; set; }
        public required string TanggalTransaksi { get; set; }
        public required string NIK { get; set; }
        public required string Nama { get; set; }
        public required string KodeKios { get; set; }
        public int IdKomoditas { get; set; }
        public required string KodeProduk { get; set; }
        public required string MID { get; set; }
        public required List<DetailTransaksiKartanDtos>? transaksi { get; set; }
    }
    public class CreateTransaksiKartanDto 
    {
        public required string ReferenceNumber { get; set; }
        public required string TanggalTransaksi { get; set; }
        public required string NIK { get; set; }
        public required string Nama { get; set; }
        public required string KodeKios { get; set; }
        public required int IdKomoditas { get; set; }
        public required string KodeProduk { get; set; }
        public required string MID { get; set; }
        public required List<DetailTransaksiKartanDtos> transaksi { get; set; }
    }

    public class DetailTransaksiKartanDtos
    {
        public required int poktanId { get; set; }
        public required string namaPoktan { get; set; }
        public required string KodeDesa { get; set; }
        public required int Qty { get; set; }
    }

    public class LastNumberDtos
    {
        public string JenisTransaksi { get; set; }
        public string NoPrefix { get; set; }
        public string LastNumber { get; set; }
    }
}
