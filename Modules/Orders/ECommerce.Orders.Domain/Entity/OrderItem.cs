using ECommerce.SharedKernel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Orders.Domain.Entity
{
    public class OrderItem : BaseEntity
    {
        public Guid OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } 

        // optional navigation property
        public virtual Order? Order { get; set; }
    } 
}
