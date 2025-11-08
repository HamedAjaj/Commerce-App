using ECommerce.Auth.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Auth.Application.Commands.Model
{
    public record RegisterUserCommand(
       string UserName,
       string Email,
       string Password,
       string FullName,
       string Country,
       string City,
       string Street,
       string ZipCode
   ) : IRequest<AuthResultDto>;
}
