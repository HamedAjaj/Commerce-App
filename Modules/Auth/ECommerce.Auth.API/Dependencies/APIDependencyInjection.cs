using ECommerce.Auth.Application.Dependency;
using ECommerce.Auth.Infrastructure.Dependencies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Asp.Versioning;

namespace ECommerce.Auth.API.Dependencies
{
    public static class APIDependencyInjection
    {
        public static IServiceCollection AddAuthModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAppplicationModule(configuration);
            services.AddInfrastructureDependencies(configuration);
            // To add controllers from another assembly

            services.AddApiVersioning(options => {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true; 
                //options.ApiVersionReader = ApiVersionReader.Combine(
                //    //new UrlSegmentApiVersionReader(),
                //    //new QueryStringApiVersionReader("api-version"),
                //    new HeaderApiVersionReader("x-api-version")
                //    );
            });
        


            // FIX: Pass the required assembly to RegisterServicesFromAssembly  
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(APIDependencyInjection).Assembly));
            services.AddControllers().AddApplicationPart(typeof(APIDependencyInjection).Assembly).AddControllersAsServices();


            return services;
        }
    }
}
