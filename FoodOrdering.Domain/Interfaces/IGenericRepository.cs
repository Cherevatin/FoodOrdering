using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodOrdering.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);

        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);

        void Remove(T entity);

        void Update(T entity);
    }
}
