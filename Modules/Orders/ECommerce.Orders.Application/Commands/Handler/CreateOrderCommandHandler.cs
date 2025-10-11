using ECommerce.Orders.Application.Commands.Model;
using ECommerce.Orders.Domain.Entity;
using ECommerce.SharedKernel.Enums;
using ECommerce.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Orders.Application.Commands.Handler
{
    public class CreateOrderCommandHandler(IRepository<Order> orderRepository) : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IRepository<Order> _orderRepository = orderRepository;
        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CustomerId = request.BuyerId,
                OrderItems = request.OrderItems,
                TotalAmount = request.TotalAmount,
                OrderDate = DateTime.Now,
                Status = OrderStatus.Created.ToString()
            };
            await _orderRepository.AddAsync(order);
            _orderRepository.SaveChangesAsync();

            return Guid.NewGuid();
        }
    }
}
