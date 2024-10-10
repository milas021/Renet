using Application.CommandResponse;
using Domain.Common;
using Infrastructure.Exceptions;
using System.Text.Json;

namespace Renet.Midllewares {
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // تنظیمات برای پشتیبانی از کاراکترهای غیر لاتین
                WriteIndented = true // برای خوانایی بهتر JSON نهایی
            };
            try
            {
                await _next(httpContext);

            }
            catch (AppException e)
            {
                
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(MessageResponse.CreateErrorMessage(e.Message) , options));
            }
            catch (Exception e)
            {
                
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(MessageResponse.CreateErrorMessage(ErrorMessage.UnkonwError),options));

            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
