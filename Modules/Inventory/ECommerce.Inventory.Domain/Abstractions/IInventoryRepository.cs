using ECommerce.Inventory.Domain.Entity;
using ECommerce.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Inventory.Domain.Abstractions
{
    public interface IInventoryRepository : IRepository<InventoryItem>
    {
        Task<InventoryItem> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken = default);
    }
}
