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
        // Domain behaviors and methods can be added here
        public void UpdateFullNme(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Full name cannot be empty.", nameof(fullName));
            }
            FullName = fullName.Trim();
        }

        public void UpdateAddress(Address address)
        {
            Address = address;
        }
    }
}
