using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.SharedKernel.Base
{
    public class AuditableEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? UserName { get; set; }
        public void MarkUpdated() => UpdatedAt = DateTime.UtcNow;
    }
}
