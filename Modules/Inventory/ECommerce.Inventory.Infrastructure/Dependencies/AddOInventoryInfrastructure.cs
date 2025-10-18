using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Inventory.Infrastructure.Dependencies
{

    public static class AddOInventoryInfrastructure
    {
        public static IServiceCollection AddInventoryInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // connection string with validation
            var connectionString = configuration.GetConnectionString("InventoryConnection")
                            ?? throw new InvalidOperationException("Connection string 'Orders' not found.");
            // DbContext
            services.AddDbContext<InventoryDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Repositories
            //services.AddScoped<IOrderRepository, OrderRepository>();

            // Unit of Work
            //services.AddScoped<OrdersUnitOfWork>();

            return services;
        }
    }
}
