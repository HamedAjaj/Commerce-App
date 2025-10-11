using ECommerce.SharedKernel.Base;
using ECommerce.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.SharedKernel.GenericRepository
{
    public class GenericRepository<TContext ,T> : IRepository<T> 
        where T : BaseEntity 
        where TContext : BaseDbContext
    {
        protected readonly TContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task AddAsync(T entity)  => await _dbSet.AddAsync(entity);

        public void DeleteAsync(T entity) => _dbSet.Remove(entity);

        public Task<bool> ExistsAsync(Guid id) => _dbSet.AnyAsync(e => e.Id == id);

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            => await _dbSet.Where(predicate).ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

        public void SaveChangesAsync() => _context.SaveChangesAsync(); 

        public void UpdateAsync(T entity) => _dbSet.Update(entity);
        
    }
}
