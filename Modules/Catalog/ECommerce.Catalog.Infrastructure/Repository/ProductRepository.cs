using ECommerce.Catalog.Domain.Entity;
using ECommerce.Catalog.Infrastructure.IRepository;
using ECommerce.SharedKernel.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Infrastructure.Repository
{
    public class ProductRepository : GenericRepository<CatalogDbContext ,Product>, IProductRepository
    {
        public ProductRepository(CatalogDbContext context):base(context) { }
    }
}
