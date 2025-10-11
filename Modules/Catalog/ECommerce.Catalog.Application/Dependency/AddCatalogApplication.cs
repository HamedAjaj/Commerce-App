using ECommerce.Catalog.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.Dependency
{
    public static class AddCatalogApplication
    {
        public static IServiceCollection AddCatalogsApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); // MediatR
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); // Fluent validation 
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>)); // To enable FluentValidation with MediatR
            return services;
        }
    }
}
