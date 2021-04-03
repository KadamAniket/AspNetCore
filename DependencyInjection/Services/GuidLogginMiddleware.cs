using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Services
{
    public static class GuidLogginMiddleware
    {
        public GuidLogginMiddleware(IGuidService guidService)
        {
            Console.WriteLine(guidService.GetGuid());

        }

        public static IApplicationBuilder GuidLogging(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
