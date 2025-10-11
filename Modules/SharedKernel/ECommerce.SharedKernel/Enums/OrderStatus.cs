using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.SharedKernel.Enums
{
    public enum OrderStatus
    {
        Created,
        Confirmed,
        Shipped,
        Delivered,
        Cancelled
    }
}
