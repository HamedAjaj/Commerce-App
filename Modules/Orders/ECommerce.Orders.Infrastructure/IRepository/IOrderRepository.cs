using ECommerce.Orders.Domain.Entity;
using ECommerce.SharedKernel.Interfaces;  

namespace ECommerce.Orders.Infrastructure.IRepository
{
    public interface IOrderRepository : IRepository<Order> , IRepositoryMarker
    {
    }
}
