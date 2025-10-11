
using ECommerce.Orders.Infrastructure.Dependency;
using ECommerce.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Orders.Infrastructure.Dependency
{
    public static class InfrastructureDependencyInjection  
    {
        public static IServiceCollection AddOrdersInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Connection string with validation
            var connectionString = configuration.GetConnectionString("OrdersConnection")
               ?? throw new InvalidOperationException("Connection string 'Orders' not found.");

            // DbContext
            services.AddDbContext<OrdersDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Repositories
            //  services.AddScoped<IRepository<Order>, OrderRepository>(); // this is manual registration
          //  services.AddScoped(IRepository,  OrderRepository);
            services.AddRepositories(); // this is reflection-based registration
            // Unit of Work
            //services.AddScoped<OrdersUnitOfWork>();
             

            return services;
        }
    }
}
