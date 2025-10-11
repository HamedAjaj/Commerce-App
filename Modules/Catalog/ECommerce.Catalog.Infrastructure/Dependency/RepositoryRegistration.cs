using ECommerce.SharedKernel.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Infrastructure.Dependency
{
    public static class RepositoryRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Register your repositories here manually or via reflection
            // services.AddScoped<IOrderRepository, OrderRepository>();  // this is manual registration

            // Reflection-based registration
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IRepositoryMarker).IsAssignableFrom(t)).ToList();
            foreach (var repoType in types)
            {
                var interfaces = repoType.GetInterfaces()
                     .Where(i => i != typeof(IRepositoryMarker));

                foreach (var ifaceType in interfaces)
                {
                    services.AddScoped(ifaceType, repoType);
                }
            }
            return services;
        }
    }
}
