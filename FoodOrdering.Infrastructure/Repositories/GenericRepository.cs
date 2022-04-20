using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using FoodOrdering.Domain.Common;

namespace FoodOrdering.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly FoodOrderingContext _context;
        protected readonly DbSet<T> _entities;

        public GenericRepository(FoodOrderingContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task AddAsync(T entity) => await _entities.AddAsync(entity);
        
        public async Task<IEnumerable<T>> GetAllAsync() => await _entities.ToListAsync();

        public async Task<T> GetByIdAsync(Guid id) => await _entities.FindAsync(id);
       
        public void Remove(T entity) => _entities.Remove(entity);
    
        public void Update(T entity) => _context.Entry(entity).State = EntityState.Modified;

    }
}
