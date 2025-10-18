using ECommerce.SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Inventory.Domain.Events
{
    public class InventoryStockIncreasedEvent : DomainEvent
    {
        public Guid ProductId { get; }
        public int Amount { get; }

        public InventoryStockIncreasedEvent(Guid productId, int amount)
        {
            ProductId = productId;
            Amount = amount;
        }
    }
}
