using ECommerce.Auth.Application.Abstractions;
using ECommerce.Auth.Application.Commands.Model;
using ECommerce.Auth.Application.DTOs;
using ECommerce.Auth.Domain.Entities;
using ECommerce.SharedKernel.ValueObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Auth.Infrastructure.Identity
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(UserManager<ApplicationUser> userManager, IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }
        public async Task<AuthResultDto> LoginAsync(LoginUserCommand command)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, command.Password))
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var token =  _jwtTokenService.GenerateToken(user, roles);
            return new AuthResultDto(token, DateTime.UtcNow.AddHours(2), user.UserName, user.Email);
        }

        public async Task<AuthResultDto> RegisterAsync(RegisterUserCommand command)
        {
             var user = new ApplicationUser
             {
                 UserName = command.UserName,
                 Email = command.Email,
                 EmailConfirmed = true
             };
            var address = new Address(command.Country, command.City, command.Street, command.ZipCode);
            
            user.UpdateAddress(address);
            user.UpdateFullName(user.UserName);

            var result = await _userManager.CreateAsync(user, command.Password);
            if (!result.Succeeded)
            {
                throw new ApplicationException(string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            var token = _jwtTokenService.GenerateToken(user, new List<string> { "Customer"});
            return new AuthResultDto(token, DateTime.UtcNow.AddHours(2), user.UserName, user.Email);

        }
    }
}
