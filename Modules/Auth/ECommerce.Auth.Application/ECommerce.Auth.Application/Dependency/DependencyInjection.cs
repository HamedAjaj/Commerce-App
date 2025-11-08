using ECommerce.Auth.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Auth.Application.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppplicationModule(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); // MediatR
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); // Fluent validation 
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>)); // To enable FluentValidation with MediatR
            return services;
        }
    }
}
