using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.SharedKernel.Interfaces
{
    public interface IRepository<T>    where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> ExistsAsync(Guid id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T , bool>> predicate);
        Task AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        void SaveChangesAsync();
    }
}
