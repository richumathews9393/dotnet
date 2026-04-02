using System.Net;
using System.Text.Json;

namespace CustomWebAPI.Middleware
{
    public class CustomErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomErrorHandlingMiddleware> _logger;

        public CustomErrorHandlingMiddleware(RequestDelegate next, ILogger<CustomErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try 
            {
                await _next(httpContext);//Proceeds to next middleware
            }
            catch (Exception e)
            {
                await HandleCustomException(httpContext, e);
            }
        }

        private static Task HandleCustomException(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return httpContext.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = "Internal Server Error from Custom Middleware.",
                Detailed = e.Message
            }));
        }
    }
}
