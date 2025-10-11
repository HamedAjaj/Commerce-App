using ECommerce.SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlHamed.Orders.Domain.Events;

public class OrderPlacedEvent : DomainEvent
{
    public Guid OrderId { get; private set; }
    public Guid CustomerId { get; private set; }
    public IReadOnlyCollection<Guid> ProductIds { get; private set; }

    public OrderPlacedEvent(Guid orderId, Guid customerId, IReadOnlyCollection<Guid> productIds)
    {
        OrderId = orderId;
        CustomerId = customerId;
        ProductIds = productIds;
    }
}

