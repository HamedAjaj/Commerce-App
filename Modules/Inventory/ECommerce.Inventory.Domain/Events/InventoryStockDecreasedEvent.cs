using ECommerce.SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Inventory.Domain.Events
{
    public class InventoryStockDecreasedEvent : DomainEvent
    {
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public InventoryStockDecreasedEvent(Guid productId, int amount)
        {
            productId = ProductId;
            amount = Amount;
        }
    }
}
