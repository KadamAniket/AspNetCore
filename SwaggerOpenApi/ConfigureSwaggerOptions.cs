using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SwaggerOpenApi.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SwaggerOpenApi
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider apiVersionDescriptionProvider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            this.apiVersionDescriptionProvider = provider;
        }
        public void Configure(SwaggerGenOptions options)
        {
            options.SwaggerDoc("Sample", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "SwaggerOpenApi Service",
                Version = "1",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = "Aniket Kadam",
                    Email = "aniketa2k@gmail.com",
                },
                License = new Microsoft.OpenApi.Models.OpenApiLicense
                {
                    Name = "SwaggerOpenAPI License",
                }
            });

            var xmlCommentsDocumentName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
            var path = Path.Combine(AppContext.BaseDirectory, xmlCommentsDocumentName);
            options.IncludeXmlComments(path);

            options.ResolveConflictingActions(apiDescription =>
            {
                return apiDescription.First();
            });

            options.OperationFilter<GetActionOperationFilter>();
        }
    }
}
