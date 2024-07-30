using System.Text.Json;
using Shared.Contract.Responses;

namespace Backend.Exceptions
{
    internal sealed class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ExternalServiceException ex)
            {
                context.Response.StatusCode = 503;
                context.Response.Headers.Add("content-type", "application/json");

                var errorResponse = new ErrorResponse(ex.ErrorCode, ex.Message);
                var json = JsonSerializer.Serialize(errorResponse);
                await context.Response.WriteAsync(json);
            }
            catch (CustomApplicationException ex)
            {
                context.Response.StatusCode = 400;
                context.Response.Headers.Add("content-type", "application/json");

                var errorResponse = new ErrorResponse(ex.ErrorCode, ex.Message);
                var json = JsonSerializer.Serialize(errorResponse);
                await context.Response.WriteAsync(json);
            }
            catch (Exception)
            {
                context.Response.StatusCode = 500;
                context.Response.Headers.Add("content-type", "application/json");

                var errorResponse = new ErrorResponse(
                    "internal_server_error",
                    "An unexpected error occurred. Please try again later.");
                var json = JsonSerializer.Serialize(errorResponse);
                await context.Response.WriteAsync(json);
            }
        }
    }
}