using ECommerce.Auth.Application.Abstractions;
using ECommerce.Auth.Application.Commands.Model;
using ECommerce.Auth.Application.DTOs;
using ECommerce.Auth.Domain.Entities;
using ECommerce.SharedKernel.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Auth.Application.Commands.Handler
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, AuthResultDto>
    {

        #region imp of insfrastructure

        //private readonly  UserManager<ApplicationUser> _userManager;
        //private readonly  RoleManager<ApplicationRole>  _roleManager;

        //public RegisterUserHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        //{
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //}

        //public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        //{
        //    var user = new ApplicationUser 
        //    {
        //        UserName = request.UserName,
        //        Email = request.Email,
        //        EmailConfirmed = true
        //    };


        //    user.UpdateFullName(request.FullName);

        //    var address = new Address(
        //        request.Country,
        //        request.City,
        //        request.Street,
        //        request.ZipCode
        //    );
        //    user.UpdateAddress(address);
        //    var result = _userManager.CreateAsync(user, request.Password);
        //    if (!result.Result.Succeeded)
        //    {
        //        throw new Exception("User registration failed: " + string.Join(", ", result.Result.Errors.Select(e => e.Description)));
        //    }

        //    if(!await _roleManager.RoleExistsAsync("Customer"))
        //    {
        //       var roleResult =  await _roleManager.CreateAsync(new ApplicationRole("Customer", "Default user role"));
        //        if (!roleResult.Succeeded)
        //        {
        //            throw new Exception("Role creation failed: " + string.Join(", ", roleResult.Errors.Select(e => e.Description)));
        //        }
        //    }
        //    return user.Id;


        //}
        #endregion

        private readonly IAuthService _authService;
        public RegisterUserHandler(IAuthService authService) =>  _authService = authService;
        
        public async Task<AuthResultDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            => await _authService.RegisterAsync(request);

    }
}
