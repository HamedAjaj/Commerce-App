using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ECommerce.SharedKernel.Base;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.SharedKernel
{
    public class BaseDbContext : DbContext          // Generic dbContext
    { 
        protected BaseDbContext(DbContextOptions options) : base(options) {}
        public DbSet<T> SetEntity<T>()  where T :BaseEntity => Set<T>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // apply configuration from current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Global softDelete Method
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var method = typeof(BaseDbContext)
                        .GetMethod(nameof(SetGlobalQueryFilter), BindingFlags.NonPublic | BindingFlags.Instance)
                        ?.MakeGenericMethod(entityType.ClrType);
                    method?.Invoke(this, new object[] { modelBuilder } );
                }
            }
        }
        private void SetGlobalQueryFilter<T>(ModelBuilder builder) where T : BaseEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
