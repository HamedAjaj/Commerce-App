using ECommerce.Auth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Auth.Infrastructure.Persistence.IAuthRepository
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync(RefreshToken token);
        Task<RefreshToken?> GetByTokenAsync(string token);
        Task UpdateAsync(RefreshToken token);
        Task<IEnumerable<RefreshToken>> GetUserTokensAsync(Guid userId);
    }
}
