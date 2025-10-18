using ECommerce.Inventory.Domain.Entity;
using ECommerce.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Inventory.Infrastructure
{

    public class InventoryDbContext : BaseDbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

        public DbSet<InventoryItem> InventoryItems => SetEntity<InventoryItem>();
        public DbSet<StockMovement> StockMovements => SetEntity<StockMovement>();
        public DbSet<Warehouse> Warehouses => SetEntity<Warehouse>();

    }
}
