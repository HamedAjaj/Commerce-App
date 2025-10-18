using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController :  ControllerBase
    {
        // Controller implementation goes here
        private readonly IMediator _mediator;
        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            return Ok("Inventory module is running.");
        }
    }
}
