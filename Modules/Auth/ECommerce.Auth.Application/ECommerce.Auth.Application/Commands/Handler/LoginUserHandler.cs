using ECommerce.Auth.Application.Abstractions;
using ECommerce.Auth.Application.Commands.Model;
using ECommerce.Auth.Application.DTOs;
using ECommerce.Auth.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Auth.Application.Commands.Handler
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, AuthResultDto>
    {
        private readonly IAuthService _authService;
        public LoginUserHandler(IAuthService  authService) => _authService = authService;

        public async Task<AuthResultDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        => await _authService.LoginAsync(request);
    }
}
