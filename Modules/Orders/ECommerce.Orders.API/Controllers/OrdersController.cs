using ECommerce.Orders.Application.Commands.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Orders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(new { message = "Orders list returned successfully." });
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderCommand createOrder)
        {
            var orderId = _mediator.Send(createOrder);
            return Ok(new { Id = orderId, message = "Order created successfully." });
        }
    }
}
