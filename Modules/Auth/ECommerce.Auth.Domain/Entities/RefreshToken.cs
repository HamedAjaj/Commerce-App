using ECommerce.SharedKernel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Auth.Domain.Entities
{

    // Rich Model for Refresh Token
    public class RefreshToken : AuditableEntity
    {
        // Fields
        public string Token { get; private set; } = default!;
        public DateTime Expires { get; private set; }
        public DateTime Created { get; private set; }
        public string CreatedByIp { get; private set; } = default!;
        public DateTime? Revoked { get; private set; }
        public string? RevokedByIp { get; private set; }
        public string? ReplacedByToken { get; private set; } 

        public ApplicationUser User { get; private set; } 

        private RefreshToken() { }

        public RefreshToken(string token, DateTime expires, string createdByIp, ApplicationUser user)
        {
            Token = token;
            Expires = expires;
            Created = DateTime.UtcNow;
            CreatedByIp = createdByIp;
            User = user;
        }

        public bool IsExpired =>  DateTime.UtcNow >= Expires;
        public bool IsActive => Revoked == null && !IsExpired;
        public void Revoke(string revokedByIp, string? replacedByToken = null)
        {
            Revoked = DateTime.UtcNow;
            RevokedByIp = revokedByIp;
            ReplacedByToken = replacedByToken;
            MarkUpdated();
        }
    }
}
