using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Auth.Application.DTOs
{ 

    public record AuthResultDto(string Token, DateTime Expiry, string Username, string Email);

    //  public record AuthResultDto(
    //    string AccessToken,
    //    DateTime AccessTokenExpiresAt,
    //    string RefreshToken,
    //    DateTime RefreshTokenExpiresAt,
    //    string UserId,
    //    string UserName,
    //    string Email
    //); 
}
