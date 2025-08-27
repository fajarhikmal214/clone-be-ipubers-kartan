namespace be_ipubers_kartan.Dtos
{
    public class TransaksiKartanPenjualan
    {
        public Models.Penjualan Ipubers { get; set; }
        public Models.Penjualan Rekan { get; set; }
    }
    
    public class TransaksiAndReversalDto
    {
        public string NoNota { get; set; }
        public string? NoReferensi { get; set; }
        public string? NoNotaBatal { get; set; }
    }
}