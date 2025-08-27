namespace be_ipubers_kartan.Dtos
{
    public class ExceptionLogDto
    {
        public DateTime Timestamp { get; set; }
        public string Path { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;
        public string Query { get; set; } = string.Empty;

        public Dictionary<string, string> RequestHeaders { get; set; } = new();
        public string RequestBody { get; set; } = string.Empty;

        public int StatusCode { get; set; }
        public string StatusMessage { get; set; } = string.Empty;

        public string ExceptionType { get; set; } = string.Empty;
        public string ExceptionMessage { get; set; } = string.Empty;
        public string? StackTrace { get; set; }
        public string TraceId { get; set; } = string.Empty;
        
        public string? CreatedBy { get; set; } = string.Empty;
    }
}