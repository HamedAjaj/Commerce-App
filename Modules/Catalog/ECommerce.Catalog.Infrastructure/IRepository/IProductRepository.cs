using ECommerce.Catalog.Domain.Entity;
using ECommerce.SharedKernel.Interfaces; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Infrastructure.IRepository
{
    public interface IProductRepository : IRepository<Product>, IRepositoryMarker
    {
    }
}
