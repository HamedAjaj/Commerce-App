using ECommerce.Orders.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Orders.Infrastructure.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {       
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
           builder.HasOne<Order>(O=>O.Order) // or hasOne<Order>() but don't add object of Order in orderItem as it is optional to avoid Shadowing problem
                  .WithMany(o=> o.OrderItems)
                  .HasForeignKey(oi => oi.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
