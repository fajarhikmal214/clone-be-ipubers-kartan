namespace be_ipubers_kartan.Constants
{
    public class HeadingMessages
    {
        public static class StokKios
        {
            public const string Success = "Proses pemanggilan data stok berhasil";
            public const string Failed = "Proses pemanggilan data stok gagal";
        }

        public static class TransaksiKartan
        {
            public const string Success = "Proses Transaksi berhasil";
            public const string Failed = "Proses Transaksi gagal";
        }

        public static class TransaksiKartanReversal
        {
            public const string Success = "Proses Transaksi berhasil";
            public const string Failed = "Proses Transaksi gagal";
        }

        public static class Default
        {
            public const string Failed = "Terjadi kesalahan pada server. Silakan coba lagi beberapa saat.";
            public const string Timeout = "Proses dibatalkan karena melebihi batas waktu yang ditentukan.";
        }
    }
}