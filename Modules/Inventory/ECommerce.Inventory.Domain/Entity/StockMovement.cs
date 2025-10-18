using ECommerce.SharedKernel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Inventory.Domain.Entity
{
    public class StockMovement : BaseEntity
    {
        public Guid InventoryItemId { get; private set; }
        public int ChangeQty { get; private set; }
        public string MovementType { get; private set; }
        public DateTime Date { get; private set; }

        private StockMovement() { }

        public StockMovement(Guid itemId, int qty, string movementType)
        {
            Id = Guid.NewGuid();
            InventoryItemId = itemId;
            ChangeQty = qty;
            MovementType = movementType ?? throw new ArgumentNullException(nameof(movementType));
            Date = DateTime.UtcNow;
        }
    }
}