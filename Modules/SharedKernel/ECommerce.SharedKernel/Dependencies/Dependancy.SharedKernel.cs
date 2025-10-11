using ECommerce.SharedKernel.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.SharedKernel.Dependencies
{
    public static class DependancyService
    {
        public static IServiceCollection AddSharedKernelDependancies(this IServiceCollection services)
        {
            /// <summary>
            ///           1.If you are in the same assembly as the validators and you can use the current assembly:
            ///   
            ///   services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            ///
            /// 2.If you have a validator class (for example, `ProductValidator`) :
            ///  
            ///   services.AddValidatorsFromAssemblyContaining<ProductValidator>();
            ///   
            ///</summary>
          
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            return services;
        }
    }

}
