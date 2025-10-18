using ECommerce.SharedKernel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Inventory.Domain.Entity
{
    public class Warehouse : BaseEntity
    {
        public string Name { get; private set; }
        public string Location { get; private set; }

        private readonly List<InventoryItem> _items = new();
        public IReadOnlyCollection<InventoryItem> Items => _items.AsReadOnly();

        private Warehouse() { }

        public Warehouse(string name, string location)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Location = location ?? throw new ArgumentNullException(nameof(location));
        }
    }
}
