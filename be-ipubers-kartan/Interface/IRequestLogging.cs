namespace be_ipubers_kartan.Interface
{
    public interface IRequestLogging
    {
        string Id { get; set; }
        long LatencyMs { get; set; }
        string? CreatedBy { get; set; }
        DateTimeOffset RequestAt { get; set; }
        DateTimeOffset ResponseAt { get; set; }
        IRequestInfo? Request { get; set; }
        IResponseInfo? Response { get; set; }
        public string? Message { get; set; }
    }

    public interface IRequestInfo
    {
        string? HttpMethod { get; set; }
        string? Endpoint { get; set; }
        string? RemoteIpAddress { get; set; }
        string? UserAgent { get; set; }
        string? Host { get; set; }
        string? Body { get; set; }
        Dictionary<string, string>? Headers { get; set; }
        string? QueryParameters { get; set; }
        public RouteValueDictionary? RouteParameters { get; set; }
    }

    public interface IResponseInfo
    {
        int? StatusCode { get; set; }
        string? Body { get; set; }
    }
}
