using System.Text.Json.Serialization;

namespace be_ipubers_kartan.Dtos
{
    public class AlokasiResponse
    {
        public int statusCode { get; set; }
        public string statusDesc { get; set; }
        public int pageNo { get; set; }
        public int pageSize { get; set; }
        public int totalData { get; set; }
        public int totalPage { get; set; }
        public DataResponse data { get; set; }
    }
    public class DataResponse
    {
        public string idRetailer { get; set; }
        public string namaKios { get; set; }
        public string kecamatan { get; set; }
        public string kelurahan { get; set; }
        public string subsektor { get; set; }
        public int tahun { get; set; }
        public List<PetaniResponse> petani { get; set; }
    }

    public class PetaniResponse
    {
        public int idRdkkPetani { get; set; }
        public string poktanId { get; set; }
        private string _kelompokTani;
        public string kelompokTani
        {
            get
            {
                return !string.IsNullOrEmpty(_kelompokTani) ? _kelompokTani.Trim() : this._kelompokTani;
            }
            set
            {
                this._kelompokTani = value.Trim();
            }
        }
        public string namaPetani { get; set; }
        public string nik { get; set; }
        public string kodeDesa { get; set; }
        public string namaDesa { get; set; }
        public string komoditas { get; set; }
        public int idKomoditas { get; set; }
        public ProdukResponse[] produk { get; set; }
        public int idPetani { get; set; }
        public int? luasTanam { get; set; }
        public int idDokumentasiPoktan { get; set; }
        public int tipeTransaksi { get; set; }
        public string noHp { get; set; }
        public string pin { get; set; }
        public string? retailer_mid { get; set; }
        public int? isPetaniKartan { get; set; }
    }

    public class ProdukResponse
    {
        public int totalKg { get; set; }
        public int idProduk { get; set; }
        public string komoditas { get; set; }
        public string kodeProduk { get; set; }
        public string namaProduk { get; set; }
        public string gambarProduk { get; set; }
        public int hargaProduk { get; set; }
        public int idKomoditas { get; set; }
        public int totalSalur { get; set; }
        public int totalAlokasi { get; set; } = 0;
    }

    public class ValidasiAlokasiResponse
    {
        public bool Selisih { get; set; }
        public int? IsPetaniKartan { get; set; }

        public string SelisihDeskripsi { get; set; }
        public string? retailer_mid { get; set; }
        public ProdukValidasiResponse product { get; set; }
    }
    public class ProdukValidasiResponse
    {
        public int Urea { get; set; }
        public int UreaAlokasi { get; set; }
        public int UreaSelisih { get; set; }
        public int Npk { get; set; }
        public int NpkAlokasi { get; set; }
        public int NpkSelisih { get; set; }
        public int Sp36 { get; set; }
        public int Sp36Alokasi { get; set; }
        public int Sp36Selisih { get; set; }
        public int Za { get; set; }
        public int ZaAlokasi { get; set; }
        public int ZaSelisih { get; set; }
        public int NpkFormula { get; set; }
        public int NpkFormulaAlokasi { get; set; }
        public int NpkFormulaSelisih { get; set; }
        public int Organic { get; set; }
        public int OrganicAlokasi { get; set; }
        public int OrganicSelisih { get; set; }
        public int Poc { get; set; }
        public int PocAlokasi { get; set; }
        public int PocSelisih { get; set; }
        public int KomoditasId { get; set; }
        public string Komoditas { get; set; }
        public string NIK { get; set; }
    }
    public class AuthAlokasiResponseDto
    {
        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }
        [JsonPropertyName("statusDesc")]
        public string StatusDesc { get; set; }
        [JsonPropertyName("statusDescHeading")]
        public string StatusDescHeading { get; set; }
        [JsonPropertyName("data")]
        public TokenDto Data { get; set; }
    }
    public class TokenDto
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
        [JsonPropertyName("expiredAt")]
        public string ExpiredAt { get; set; }

    }
}
