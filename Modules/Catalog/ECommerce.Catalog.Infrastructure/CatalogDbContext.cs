using ECommerce.Catalog.Domain.Entity;
using ECommerce.Catalog.Infrastructure.Configurations;
using ECommerce.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Infrastructure
{
    public class CatalogDbContext : BaseDbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }

        // Define DbSets for your entities
        public DbSet<Product> Products => SetEntity<Product>();
        public DbSet<Category> Categories => SetEntity<Category>();
        public DbSet<Brand> Brands => SetEntity<Brand>();
        public DbSet<ProductReview> ProductReviews => SetEntity<ProductReview>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
        }
    }
}
