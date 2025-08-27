using be_ipubers_kartan.Models;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace be_ipubers_kartan.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, IConfiguration configuration, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            DateTimeOffset requestAt = DateTimeOffset.UtcNow;

            string id = context.TraceIdentifier;

            string createdBy = "Anonymous";
            if (context.User.Identity?.IsAuthenticated == true)
            {
                createdBy = context.User.FindFirst(ClaimTypes.Name)?.Value ?? context.User.Identity.Name;
            }

            var log = new RequestLogging
            {
                Id = id,
                CreatedBy = createdBy,
                RequestAt = requestAt,
                Request = new RequestInfo
                {
                    HttpMethod = context.Request.Method,
                    Endpoint = context.Request.Path.ToString(),
                    RemoteIpAddress = context.Connection.RemoteIpAddress?.ToString(),
                    UserAgent = context.Request.Headers.TryGetValue("User-Agent", out var userAgent) ? userAgent.ToString() : null,
                    Host = context.Request.Host.ToString(),
                    Headers = context.Request.Headers
                        .Where(h => !h.Key.Equals("Authorization", StringComparison.OrdinalIgnoreCase) &&
                                    !h.Key.Equals("Cookie", StringComparison.OrdinalIgnoreCase) &&
                                    !h.Key.Equals("User-Agent", StringComparison.OrdinalIgnoreCase) &&
                                    !h.Key.StartsWith("X-", StringComparison.OrdinalIgnoreCase))
                        .ToDictionary(h => h.Key, h => h.Value.ToString())
                },
                Response = new ResponseInfo()
            };

            log.Request.QueryParameters = context.Request.QueryString.ToString();
            log.Request.RouteParameters = context.Request.RouteValues;

            context.Request.EnableBuffering();
            using (var requestStream = new MemoryStream())
            {
                await context.Request.Body.CopyToAsync(requestStream);
                requestStream.Position = 0;

                string requestBodyString = string.Empty;
                using (var reader = new StreamReader(requestStream, Encoding.UTF8))
                {
                    requestBodyString = await reader.ReadToEndAsync();
                }

                if (!string.IsNullOrEmpty(requestBodyString))
                {
                    log.Request.Body = requestBodyString;
                }

                context.Request.Body.Position = 0;
            }

            var originalBodyStream = context.Response.Body;
            using (var responseBodyStream = new MemoryStream())
            {
                context.Response.Body = responseBodyStream;

                try
                {
                    await _next(context);
                }
                finally
                {
                    stopwatch.Stop();

                    log.LatencyMs = stopwatch.ElapsedMilliseconds;
                    log.ResponseAt = DateTimeOffset.UtcNow;
                    log.Response.StatusCode = context.Response.StatusCode;

                    responseBodyStream.Position = 0;
                    string responseBodyString = string.Empty;

                    using (var reader = new StreamReader(responseBodyStream, Encoding.UTF8, true, 1024, leaveOpen: true))
                    {
                        responseBodyString = await reader.ReadToEndAsync();
                    }

                    if (!string.IsNullOrEmpty(responseBodyString))
                    {
                        log.Response.Body = responseBodyString;

                        try
                        {
                            var response = JsonDocument.Parse(responseBodyString);

                            if (response.RootElement.TryGetProperty("statusDesc", out JsonElement statusDescElement))
                            {
                                log.Message = statusDescElement.ToString();
                            }
                            else
                            {
                                log.Message = "No Message";
                            }
                        }
                        catch (JsonException)
                        {
                            log.Message = "No Message";
                        }
                    }

                    var method = log.Request.HttpMethod;
                    var path = log.Request.Endpoint;
                    var statusCode = log.Response.StatusCode;

                    // Server errors (5xx)
                    if (statusCode >= 500)
                    {
                        // _logger.LogError("HTTP {Method} {Path} responded with {StatusCode} (Server Error). Details: {@log}", method, path, statusCode, log);
                    }

                    // Client errors (4xx)
                    else if (statusCode >= 400)
                    {
                        // _logger.LogWarning("HTTP {Method} {Path} responded with {StatusCode} (Client Error). Details: {@log}", method, path, statusCode, log);
                    }

                    // Informational and success (1xx, 2xx, 3xx)
                    else
                    {
                        // _logger.LogInformation("HTTP {Method} {Path} responded with {StatusCode}. Details: {@log}", method, path, statusCode, log);
                    }

                    if (responseBodyStream.CanSeek)
                    {
                        responseBodyStream.Position = 0;
                        await responseBodyStream.CopyToAsync(originalBodyStream);
                    }

                    context.Response.Body = originalBodyStream;
                }
            }
        }
    }
}
