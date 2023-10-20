using System.Net;
using Twitter.Repository;

namespace Twitter.WebAPI.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void ConfigureExceptionMiddleware(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var flag = context.RequestServices.GetService<RepositoryErrorFlag>();
                    flag!.Flag = true;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(new 
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Error"
                    }.ToString()!);
                });
            });
        }
    }
}
