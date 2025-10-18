using ECommerce.Orders.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Orders.Infrastructure.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {       
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
           builder.HasOne<Order>()                 // dependent -> principal
                  .WithMany(o => o.OrderItems)     // use the Order.OrderItems navigation to avoid a second relationship
                  .HasForeignKey(oi => oi.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}