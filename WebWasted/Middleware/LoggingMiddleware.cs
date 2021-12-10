using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebWasted.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if(httpContext == null)
            {
                Logger.Instance.Log("Empty Request");
                await _next(httpContext);
                return;

            }
            Logger.Instance.Log("Incoming " + httpContext.Request.Method + " request to: " + httpContext.Request.Path.Value);
            httpContext.Request.EnableBuffering();
            httpContext.Request.Body.Seek(0, SeekOrigin.Begin);

            using (var reader = new StreamReader(httpContext.Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                Logger.Instance.Log("Incoming body data: " + JsonConvert.SerializeObject(body));
                httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            }
            await _next(httpContext);
            //Logger.Instance.Log("Response data: " + JsonConvert.SerializeObject(httpContext.Response));
           /*
            using (var reader = new StreamReader(httpContext.Response.Body))
            {
                var body = await reader.ReadToEndAsync();
                Logger.Instance.Log("Outgoing body data: " + JsonConvert.SerializeObject(body));
                httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            }
           */
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
