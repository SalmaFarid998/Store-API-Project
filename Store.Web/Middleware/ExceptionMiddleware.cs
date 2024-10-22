using Store.Service.HandleResponse;
using System.Net;
using System.Text.Json;

namespace Store.Web.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment environment;

        public ExceptionMiddleware(RequestDelegate Next, ILogger<ExceptionMiddleware> logger, IHostEnvironment environment)
        {
            next = Next;
            this.logger = logger;
            this.environment = environment;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                {
                    logger.LogError(ex, ex.Message);
                    context.Response.ContentType= "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    var ResponseEnv = environment.IsDevelopment() ? new CustomException(500,ex.Message,ex.StackTrace.ToString()):new CustomException((int)HttpStatusCode.InternalServerError);

                    var Options = new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                    var jsonResponse = JsonSerializer.Serialize(ResponseEnv, Options); 
                    await context.Response.WriteAsync(jsonResponse);
                }
            }
        }
    }
}
