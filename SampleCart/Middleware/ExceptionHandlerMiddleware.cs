using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SampleCart.Services.CustomException;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MeccaTest.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }
        private Task ConvertException(HttpContext context, Exception exception)
        {

            HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest;

            context.Response.ContentType = "application/json";

            var result = string.Empty;

            switch (exception)
            {
                case InvalidPlacedOrderException invalidPlacedOrderException:
                    result = JsonConvert.SerializeObject(new { error = invalidPlacedOrderException.Message });
                    break;
                case InvalidOrderException invalidOrderException:
                    result = JsonConvert.SerializeObject(new { error = invalidOrderException.Message });
                    break;
                case Exception ex:
                    httpStatusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;
            if (result == string.Empty) result = JsonConvert.SerializeObject(new { error = exception.Message });

            return context.Response.WriteAsync(result);

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
