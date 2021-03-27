using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace MvcMovie.Logging
{
    public class ResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseLoggingMiddleware(RequestDelegate next)
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
                Console.WriteLine($"[{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss:ms")}]\nResponse:\n<Body = {context.Response?.Body}\nContent type = {context.Response?.ContentType} \nStatus code = {context.Response?.StatusCode}>\n");
            }
        }
    }
}