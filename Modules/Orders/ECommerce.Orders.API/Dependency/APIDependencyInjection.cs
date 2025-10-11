using ECommerce.Orders.Application.Dependency;
using ECommerce.Orders.Infrastructure.Dependency;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 

namespace ECommerce.Orders.API.Dependency
{
    public static class APIDependencyInjection
    {
        public static IServiceCollection AddOrdersModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOrdersApplication();
            services.AddOrdersInfrastructure(configuration);
            // To add controllers from another assembly


            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(OrdersApplicationMarker).Assembly));
            services.AddControllers().AddApplicationPart(typeof(APIDependencyInjection).Assembly).AddControllersAsServices();
            return services;
        }
    }
}
