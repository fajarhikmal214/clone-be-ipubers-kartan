using System.Text.Json;
using be_ipubers_kartan.Constants;
using be_ipubers_kartan.Dtos;
using be_ipubers_kartan.Exceptions;
using be_ipubers_kartan.Helpers;
using be_ipubers_kartan.Interface;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Data.SqlClient;

namespace be_ipubers_kartan.Handlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly IConfiguration _configuration;
        private readonly IElasticLoggingService _elasticLoggingService;

        public GlobalExceptionHandler(IConfiguration configuration, IElasticLoggingService elasticLoggingService)
        {
            _configuration = configuration;
            _elasticLoggingService = elasticLoggingService;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var statusCode = MapExceptionToStatusCode(exception);
            var statusCodeResponse = MapExceptionToStatusCodeResponse(exception);
            var statusDescHeading = MapExceptionToStatusDescHeading(exception);

            var clientResponse = new ModelResultDtos()
            {
                StatusCode = statusCodeResponse,
                StatusDesc = exception.Message,
                StatusDescHeading = statusDescHeading
            };

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            // Build and send log to Elasticsearch
            var errorLog = await ExceptionLogBuilder.BuildAsync(httpContext, exception);
            errorLog.StatusMessage = statusDescHeading;

            // Insert log to Elasticsearch
            InsertLogToElastic(errorLog);

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(clientResponse), cancellationToken);

            return true;
        }
        
        private void InsertLogToElastic(ExceptionLogDto errorLog)
        {
            string isEnable = _configuration.GetSection("Elasticsearch")["Uri"];
            if (isEnable == null)
            {
                return;
            }

            _ = Task.Run(async () =>
            {
                try
                {
                    await _elasticLoggingService.IndexErrorLogAsync(errorLog);
                }
                catch (Exception ex)
                {
                    // Log to a local file or ignore

                    Console.WriteLine("Failed to index log to Elasticsearch:");
                    Console.WriteLine(ex);
                }
            });
        }

        private static int MapExceptionToStatusCode(Exception exception)
        {
            return exception switch
            {
                BusinessRuleViolationException bre => bre.StatusCode,

                OperationCanceledException => StatusCodes.Status400BadRequest,

                ArgumentNullException => StatusCodes.Status500InternalServerError,

                SqlException => StatusCodes.Status500InternalServerError,

                _ => StatusCodes.Status500InternalServerError
            };
        }

        private static int MapExceptionToStatusCodeResponse(Exception exception)
        {
            return exception switch
            {
                BusinessRuleViolationException bre => bre.StatusCodeResponse,

                OperationCanceledException => StatusCodes.Status400BadRequest,

                ArgumentNullException => StatusCodes.Status500InternalServerError,

                SqlException => StatusCodes.Status500InternalServerError,

                _ => StatusCodes.Status500InternalServerError
            };
        }

        private static string MapExceptionToStatusDescHeading(Exception exception)
        {
            return exception switch
            {
                BusinessRuleViolationException bre => bre.StatusDescHeading ?? HeadingMessages.Default.Failed,

                _ => HeadingMessages.Default.Failed
            };
        }
    }
}
