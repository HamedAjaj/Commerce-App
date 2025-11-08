using ECommerce.Auth.Application.Commands.Model;
using ECommerce.Auth.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Auth.Application.Abstractions
{
    public interface IAuthService
    {
        Task<AuthResultDto> RegisterAsync(RegisterUserCommand command);
        Task<AuthResultDto> LoginAsync(LoginUserCommand command);
    }
}
