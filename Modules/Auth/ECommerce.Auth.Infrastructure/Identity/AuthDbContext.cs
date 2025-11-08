using ECommerce.Auth.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Auth.Infrastructure.Identity
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid> 
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        } 
        override protected void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Apply configurations from the current assembly
            builder.ApplyConfigurationsFromAssembly(typeof(AuthDbContext).Assembly);
        }

      
    }
}

