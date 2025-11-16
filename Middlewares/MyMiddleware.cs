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

        public Task Invoke(HttpContext context, [FromKeyedServices("scoped")] IMyService myScopedService)
        {
            //Console.WriteLine("Singleton: " + _mySingletonService.Name);
            //Console.WriteLine("Scoped: " + myScopedService.Name);

            return _next(context);
        }
    }
}