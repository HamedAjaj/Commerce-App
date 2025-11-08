using ECommerce.SharedKernel.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Auth.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public Address? Address { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

        public ApplicationUser() { } 
        public ApplicationUser(string userName, string email, string fullName) : base(userName)
        {
            Id = Guid.NewGuid();
            userName = userName;
            Email = email;
            FullName = fullName;
            EmailConfirmed = false;
        }

        // Domain behaviors and methods can be added here
        public void  UpdateFullName(string fullName)
        {  if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("Full name required");
            FullName = fullName.Trim();
        }

     

        public void UpdateAddress(Address address)
        {
            Address = address;
        }
    }
}
