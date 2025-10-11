using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Infrastructure.Dependency
{
    public static  class AddCatalogInfrastructure
    {
        public static IServiceCollection AddCatalogsInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // connection string with validation
            var connectionString = configuration.GetConnectionString("CatalogConnection")
                            ?? throw new InvalidOperationException("Connection string 'Orders' not found.");
            // DbContext
            services.AddDbContext<CatalogDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddRepositories(); // this is reflection-based registration

            // Repositories
            //services.AddScoped<IOrderRepository, OrderRepository>();

            // Unit of Work
            //services.AddScoped<OrdersUnitOfWork>();

            return services;
        }
    }
}
