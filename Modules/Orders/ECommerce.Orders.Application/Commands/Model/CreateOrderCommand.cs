using MediatR;
using ECommerce.Orders.Domain.Entity;
using ECommerce.SharedKernel.Enums;
using System.Collections.Generic;
using System;
using ECommerce.SharedKernel.ValueObjects;

namespace ECommerce.Orders.Application.Commands.Model
{
    public record CreateOrderCommand : IRequest<Guid>
    {
        public string BuyerId { get; init; }
        public Address? Address { get; init; }
        public decimal TotalAmount { get; init; }
        public List<OrderItem> OrderItems { get; init; }
    }
}
