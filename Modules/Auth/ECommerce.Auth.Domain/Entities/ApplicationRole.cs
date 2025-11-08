using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Auth.Domain.Entities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
        // Domain behaviors and methods can be added here
        public ApplicationRole(string name, string description=""):base(name)
        {
            Description = description;
        }
    }
}
 