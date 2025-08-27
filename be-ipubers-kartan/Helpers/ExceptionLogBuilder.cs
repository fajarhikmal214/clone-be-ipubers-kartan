using System.Security.Claims;
using be_ipubers_kartan.Dtos;

namespace be_ipubers_kartan.Helpers
{
    public class ExceptionLogBuilder
    {
        public static async Task<ExceptionLogDto> BuildAsync(HttpContext context, Exception exception)
        {
            context.Request.EnableBuffering();

            string requestBody = string.Empty;
            if (context.Request.ContentLength > 0 && context.Request.Body.CanSeek)
            {
                context.Request.Body.Position = 0;
                
                using var reader = new StreamReader(context.Request.Body, leaveOpen: true);
                requestBody = await reader.ReadToEndAsync();

                context.Request.Body.Position = 0;
            }
            
            string createdBy = "Anonymous";
            if (context.User.Identity?.IsAuthenticated == true)
            {
                createdBy = context.User.FindFirst(ClaimTypes.Name)?.Value ?? context.User.Identity.Name;
            }

            var sensitiveHeaders = new[] { "Authorization", "Cookie", "Set-Cookie" };
            var requestHeaders = context.Request.Headers
                .Where(h => !sensitiveHeaders.Contains(h.Key, StringComparer.OrdinalIgnoreCase))
                .ToDictionary(k => k.Key, v => v.Value.ToString());

            return new ExceptionLogDto()
            {
                Timestamp = DateTime.UtcNow,
                Path = context.Request.Path,
                Method = context.Request.Method,
                Query = context.Request.QueryString.ToString(),

                RequestHeaders = requestHeaders,
                RequestBody = requestBody,

                StatusCode = context.Response.StatusCode,

                ExceptionType = exception.GetType().Name,
                ExceptionMessage = exception.Message,
                StackTrace = exception.StackTrace,
                TraceId = context.TraceIdentifier,

                CreatedBy = createdBy
            };
        }
    }
}