using be_ipubers_kartan.Interface;

namespace be_ipubers_kartan.Models
{
    public class RequestLogging : IRequestLogging
    {
        public string Id { get; set; }
        public long LatencyMs { get; set; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset RequestAt { get; set; }
        public DateTimeOffset ResponseAt { get; set; }
        public IRequestInfo? Request { get; set; }
        public IResponseInfo? Response { get; set; }
        public string? Message { get; set; }
    }

    public class RequestInfo : IRequestInfo
    {
        public string? HttpMethod { get; set; }
        public string? Endpoint { get; set; }
        public string? RemoteIpAddress { get; set; }
        public string? UserAgent { get; set; }
        public string? Host { get; set; }
        public string? Body { get; set; }
        public Dictionary<string, string>? Headers { get; set; }
        public string? QueryParameters { get; set; }
        public RouteValueDictionary? RouteParameters { get; set; }
    }

    public class ResponseInfo : IResponseInfo
    {
        public int? StatusCode { get; set; }
        public string? Body { get; set; }
    }
}
