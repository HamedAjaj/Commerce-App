using ECommerce.Auth.Application.Commands.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Auth.Application.Validators
{
    public class LoginUserValidator : AbstractValidator<LoginUserCommand>   
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("A valid email address is required.");
        }
    }
}
