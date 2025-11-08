using Asp.Versioning;
using ECommerce.Auth.Application.Commands.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Auth.API.Controller
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;
        public AuthController(IMediator mediator) => _mediator = mediator;

        [MapToApiVersion("1.0")]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
            => Ok(await _mediator.Send(command));

        [MapToApiVersion("1.0")]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
            => Ok(await _mediator.Send(command));
    }
}
