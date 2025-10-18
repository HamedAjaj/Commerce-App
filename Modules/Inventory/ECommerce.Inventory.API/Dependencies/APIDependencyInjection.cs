using ECommerce.Inventory.Application.Dependencies;
using ECommerce.Inventory.Infrastructure.Dependencies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Inventory.API.Dependencies
{
    public static class APIDependencyInjection
    {
        public static IServiceCollection AddInventoryModule(this IServiceCollection services, IConfiguration configuration)
        {
            // Application Layer (MediatR, FluentValidation, etc.)
            services.AddInventoryApplication();
            services.AddInventoryInfrastructure(configuration);

            // this is repeated I will remove it in the future
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(InventoryApplicationMaker).Assembly));
            services.AddControllers().AddApplicationPart(typeof(InventoryApplicationMaker).Assembly).AddControllersAsServices();
            return services; 
        } 
    }
}
