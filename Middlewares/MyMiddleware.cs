using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoundTheCodeDotNet9.Interfaces;

namespace RoundTheCodeDotNet9.Middlewares
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMyService _mySingletonService;

        public MyMiddleware(RequestDelegate next, [FromKeyedServices("singleton")] IMyService mySingletonService)
        {
            _next = next;
            _mySingletonService = mySingletonService;
        }

        public async Task Invoke(HttpContext context, [FromKeyedServices("scoped")] IMyService myScopedService)
        {
            // Query parameters
            var page = context.Request.Query["page"];

            // Route parameters
            var id = context.Request.RouteValues["id"]?.ToString();

            // Headers
            var token = context.Request.Headers["Authorization"].ToString();

            // Body
            context.Request.EnableBuffering();
            using var reader = new StreamReader(context.Request.Body, leaveOpen: true);
            string body = await reader.ReadToEndAsync();
            context.Request.Body.Position = 0;

            Console.WriteLine($"Query page = {page}");
            Console.WriteLine($"Route id = {id}");
            Console.WriteLine($"Header token = {token}");
            Console.WriteLine($"Body = {body}");

            //Console.WriteLine("Singleton: " + _mySingletonService.Name);
            //Console.WriteLine("Scoped: " + myScopedService.Name);

            await _next(context);
        }
    }
}