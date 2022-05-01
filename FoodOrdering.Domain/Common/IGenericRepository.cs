using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodOrdering.Domain.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(Guid id);

        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);

        void Remove(T entity);

        void Update(T entity);
    }
}
