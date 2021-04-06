using DependencyInjectionWebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionWebApi
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
            // services.AddTransient<IGuidService, GuidService>();
            // services.AddScoped<IGuidService, GuidService>();
            // services.AddSingleton<IGuidService, GuidService>();

            // This below code will throw error due to Captive dependencies
            services.AddSingleton<IGuidService, GuidService>();
            services.AddSingleton<ISingletonService, SingletonService>();

            // Register Services using ServiceDescriptor
            services.Add(new ServiceDescriptor(typeof(IServiceDescriptorService), typeof(ServiceDescriptorService), ServiceLifetime.Scoped));
            services.Add(ServiceDescriptor.Scoped<IServiceDescriptorService, ServiceDescriptorService>());

            // Logger registration
            // Will not add Logger2 since Logger1 is already registered
            services.AddScoped<ICustomLogger, Logger1>();
            services.AddScoped<ICustomLogger, Logger2>();
            // services.TryAddScoped<ICustomLogger, Logger2>();

            // Will reemove all existing ICustomLogger registrations
            //services.RemoveAll<ICustomLogger>();
            //services.AddScoped<ICustomLogger, Logger3>();


            // Same Contract multiple implementations 
            services.TryAddEnumerable(ServiceDescriptor.Scoped<ICustomLogger, Logger1>());
            services.TryAddEnumerable(ServiceDescriptor.Scoped<ICustomLogger, Logger2>());
            services.TryAddEnumerable(ServiceDescriptor.Scoped<ICustomLogger, Logger3>());
            services.TryAddEnumerable(ServiceDescriptor.Scoped<ICustomLogger, Logger4>());
            services.TryAddEnumerable(ServiceDescriptor.Scoped<ICustomLogger, Logger1>());

            services.AddScoped<IGreetings, Greetings>();

            // Registering Generic Services
            services.TryAddSingleton(typeof(ICache<>), typeof(Cache<>));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
