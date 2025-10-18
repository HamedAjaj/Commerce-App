using ECommerce.SharedKernel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Inventory.Domain.Entity
{
    public class InventoryItem : BaseEntity
    {
        public int QuantityAvailable { get; set; }
        public Guid ProductId { get; private set; }
        public Guid WarehouseId { get; private set; }

        private readonly List<StockMovement> _movements = new();
        public IReadOnlyCollection<StockMovement> Movements => _movements.AsReadOnly();

        private InventoryItem() { }

        public InventoryItem(Guid productId, Guid warehouseId, int quantity)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            WarehouseId = warehouseId;
            QuantityAvailable = quantity >= 0 ? quantity : throw new ArgumentException("Quantity cannot be negative.");
        }

        public void AddStock(int qty)
        {
            if (qty <= 0) throw new ArgumentException("Quantity must be positive.");
            QuantityAvailable += qty;
            _movements.Add(new StockMovement(Id, qty, "Add"));
        }

        public void RemoveStock(int qty)
        {
            if (qty <= 0) throw new ArgumentException("Quantity must be positive.");
            if (QuantityAvailable < qty) throw new InvalidOperationException("Not enough stock.");
            QuantityAvailable -= qty;
            _movements.Add(new StockMovement(Id, -qty, "Remove"));
        }
    }
}
