using ECommerce.Orders.Infrastructure;
using ECommerce.Orders.Domain.Entity;
using ECommerce.SharedKernel.GenericRepository;
using ECommerce.SharedKernel.Interfaces; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Orders.Infrastructure.Repository
{
    public class OrderRepository : GenericRepository<OrdersDbContext, Order> , IRepository<Order>, IRepositoryMarker
    {
        public OrderRepository( OrdersDbContext context) :base(context) {}        
    }
}
