using ECommerce.Orders.Domain.Entity;
using ECommerce.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Orders.Infrastructure
{
    public class OrdersDbContext : BaseDbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)  { }
         
        public DbSet<Order> Orders => SetEntity<Order>();
        public DbSet<OrderItem> OrderItems => SetEntity<OrderItem>();
    }
}
