using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace TrainingProject.Core.Middlwares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                _logger.LogInformation(
                "\n Request {method} {url} {query} => {statusCode} \n {body}",
                context.Request?.Method,
                context.Request?.Path.Value,
                context.Request?.Query,
                context.Response?.StatusCode,
                context.Request?.Body);
            }
        }
    }
}