using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace MvcMovie.Logging
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                Console.WriteLine($"[{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss:ms")}]\nRequest:\n<Protocol = {context.Request?.Protocol}\nMethod = {context.Request?.Method} \nPath = {context.Request?.Path.Value} \nStatus code = {context.Response?.StatusCode}>\n");

            }
        }
    }
}