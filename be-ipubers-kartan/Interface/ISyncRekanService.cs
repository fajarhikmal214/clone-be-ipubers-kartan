using be_ipubers_kartan.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace be_ipubers_kartan.Interface
{
    public interface ISyncRekanService
    {
        Task<ResponseSyncRekanAllDto> SyncToRekanByIdRetailer(string idretailer, string token, CancellationToken cancellationToken);
        Task<ResponseCheckStokDto> CheckStok(Penjualan model, string token, string idkecamatan, string kodeProduk, CancellationToken cancellationToken);
    }
    public class ResponseSyncRekanAllDto
    {
        public bool SyncBerhasil { get; set; }
        public string Header { get; set; }
        public string Message { get; set; }
    }
    public class CustomDateTimeConverter : JsonConverter<DateTime>
    {
        private readonly string Format;
        public CustomDateTimeConverter(string format)
        {
            Format = format;
        }
        public override void Write(Utf8JsonWriter writer, DateTime date, JsonSerializerOptions options)
        {
            writer.WriteStringValue(date.ToString(Format));
        }
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), Format, null);
        }
    }
    public class ResponseCheckStokDto
    {
        public double stockAwal { get; set; }
        public bool StokCukup { get; set; }
        public string Header { get; set; }
        public string Message { get; set; }
    }
}
