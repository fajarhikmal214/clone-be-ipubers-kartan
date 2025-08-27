namespace be_ipubers_kartan.Exceptions
{
    public class BusinessRuleViolationException : Exception
    {
        public int StatusCode { get; set; }
        public int StatusCodeResponse { get; set; }
        public string? StatusDescHeading { get; set; }

        public BusinessRuleViolationException(string message, int statusCode = 400, string? heading = null) : base(message)
        {
            StatusCodeResponse = statusCode;
            StatusCode = NormalizeStatusCode(statusCode);
            StatusDescHeading = heading;
        }

        private int NormalizeStatusCode(int statusCode)
        {
            if (statusCode >= 200 && statusCode < 300) return 200;
            if (statusCode >= 400 && statusCode < 500) return 400;
            if (statusCode >= 500 && statusCode < 600) return 500;

            return statusCode;
        }
    }
}