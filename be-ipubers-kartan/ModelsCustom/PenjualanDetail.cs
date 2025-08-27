namespace be_ipubers_kartan.ModelsCustom
{
    public class PenjualanDetail
    {
        public int Id { get; set; }
        public Penjualan Penjualan { get; set; }
        public decimal Persentase { get; set; }
        public decimal Nilai { get; set; }
        public double Qty { get; set; }
    }
}
