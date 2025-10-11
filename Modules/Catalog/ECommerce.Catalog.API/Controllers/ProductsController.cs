using ECommerce.Catalog.Application.Commands.Products.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(new { message = "Products list returned successfully." });
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateProductCommand  command)
        { 
            return Ok( await _mediator.Send(command));
        }
        

    }
}
