using ECommerce.Auth.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Auth.Application.Commands.Model
{
    public record RefreshTokenCommand(string RefreshToken) : IRequest<AuthResultDto>;
}
