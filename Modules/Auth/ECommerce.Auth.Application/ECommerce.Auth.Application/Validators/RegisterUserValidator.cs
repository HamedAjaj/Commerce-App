using ECommerce.Auth.Application.Commands.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Auth.Application.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator() { 
            RuleFor(x=>x.FullName).NotEmpty().MinimumLength(3)
                .WithMessage("Full Name must be at least 3 characters long.");
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(3)
                .WithMessage("Username must be at least 3 characters long.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.");

        }
    }
}
