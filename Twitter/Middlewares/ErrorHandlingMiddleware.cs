using System.Dynamic;
using System.Text.Json;
using Twitter.Domain.Exceptions;
using Twitter.Repository;

namespace Twitter.WebAPI.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                var flag = context.RequestServices.GetService<RepositoryErrorFlag>();
                flag!.Flag = true;

                dynamic errorModel = new ExpandoObject();
                errorModel.Message = ex.Message;
                switch(ex)
                {
                    case NotFoundException:
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        break;
                    case ValidationException:
                        errorModel.Details = ((ValidationException)ex).Messages;
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    default:
                        errorModel.Message = "Something went wrong";
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize((ExpandoObject)errorModel));
            }
        }
    }
}
