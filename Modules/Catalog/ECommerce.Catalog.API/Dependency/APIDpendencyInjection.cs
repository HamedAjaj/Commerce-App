
using ECommerce.Catalog.Application.Dependency;
using ECommerce.Catalog.Infrastructure.Dependency;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.API.Dependency
{
    public static class APIDpendencyInjection
    {
        public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
        {
            // Application Layer (MediatR, FluentValidation, etc.)
            services.AddCatalogsApplication();
            services.AddCatalogsInfrastructure(configuration);

            // To add controllers from another assembly

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CatalogApplicationMaker).Assembly));
            services.AddControllers().AddApplicationPart(typeof(APIDpendencyInjection).Assembly).AddControllersAsServices();
            return services; 
        }
    }
}
