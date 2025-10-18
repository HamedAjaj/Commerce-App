using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Inventory.Application.Dependencies
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddInventoryApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); // MediatR
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); // Fluent validation 
            return services;
        }
    }
}
