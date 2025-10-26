using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private RequestDelegate requestDelegate;
        private ILogger<ExceptionHandlingMiddleware> logger;

        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandlingMiddleware> logger) 
        { 
            this.requestDelegate = requestDelegate;
            this.logger = logger;   
        }

        public async System.Threading.Tasks.Task Invoke(HttpContext context) 
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception");

                await HandleExceptionAsync(context, ex);
            }
        }

        private async System.Threading.Tasks.Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string title = "An unexpected error occurred";

            if (exception is KeyNotFoundException)
            {
                statusCode = HttpStatusCode.NotFound;
                title = "Resource not found";
            }
            else if (exception is ArgumentException)
            {
                statusCode = HttpStatusCode.BadRequest;
                title = "Invalid request data";
            }

            var problem = new
            {
                type = "https://httpstatuses.com/" + (int)statusCode,
                title,
                status = (int)statusCode,
                detail = exception.Message,
                traceId = context.TraceIdentifier
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
        }
    }
}
