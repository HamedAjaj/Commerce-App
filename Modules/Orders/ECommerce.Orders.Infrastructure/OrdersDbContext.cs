using ECommerce.Orders.Domain.Entity;
using ECommerce.Orders.Infrastructure.Configurations;
using ECommerce.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Orders.Infrastructure
{
    public class OrdersDbContext : BaseDbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)  { }
         
        public DbSet<Order> Orders => SetEntity<Order>();
        public DbSet<OrderItem> OrderItems => SetEntity<OrderItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        }
    }
}
