using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.SharedKernel.Events
{
    public class DomainEvent : INotification
    {
        public Guid Id { get; private set; }
        public DateTime OccurredOn { get; private set; }
        public bool IsPublished { get; set; } = false;

        protected DomainEvent()
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
        }
    }
}
