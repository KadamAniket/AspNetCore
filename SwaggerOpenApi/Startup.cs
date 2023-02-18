using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
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
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            });

            // Support for API Versioning
            services.AddApiVersioning(setupAction =>
            {
                setupAction.AssumeDefaultVersionWhenUnspecified = true;
                setupAction.DefaultApiVersion = new ApiVersion(1, 0);
                setupAction.ReportApiVersions = true;
            });

            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            // This code is replaced by ConfigureSwaggerOptions
            services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc("SwaggerOpenApi", new Microsoft.OpenApi.Models.OpenApiInfo
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

                options.AddSecurityDefinition("BasicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "Basic",
                });

                options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basicAuth" }
                        }, new List<string>() }
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("swagger/SwaggerOpenApi/swagger.json", "SwaggerOpenApi");
                setupAction.RoutePrefix = "";

                        });

            // app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
