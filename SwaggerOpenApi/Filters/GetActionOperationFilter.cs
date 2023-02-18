using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerOpenApi.Filters
{
    public class GetActionOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
       {
            //if (operation.OperationId != "Drivers")
            //{
            //    return;
            //}

            //operation.Responses[StatusCodes.Status200OK.ToString()].Content.Add(
            //    "application/driverWithTeam+json", new OpenApiMediaType());
        }
    }
}
