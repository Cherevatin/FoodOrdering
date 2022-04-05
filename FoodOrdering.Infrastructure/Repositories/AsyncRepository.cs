using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using FoodOrdering.Domain.Common;
using FoodOrdering.Domain.Interfaces;

namespace FoodOrdering.Infrastructure.Repositories
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly FoodOrderingContext _foodOrderingContext;
        private DbSet<T> _entities;

        public AsyncRepository(FoodOrderingContext foodOrderingContext)
        {
            _foodOrderingContext = foodOrderingContext;
            _entities = _foodOrderingContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await _foodOrderingContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _entities.ToListAsync();

        public async Task<T> GetByIdAsync(Guid id) => await _entities.FindAsync(id);
       
        public Task RemoveAsync(T entity)
        {
            _entities.Remove(entity);
            return _foodOrderingContext.SaveChangesAsync();
        }

        public Task UpdateAsync(T entity)
        {
            _foodOrderingContext.Entry(entity).State = EntityState.Modified;
            return _foodOrderingContext.SaveChangesAsync();
        }

        public async Task<bool> IsExists(Guid id) => await _entities.AnyAsync(e => e.Id == id);
      
    }
}
