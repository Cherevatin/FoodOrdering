using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task RemoveAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync();
    }
}
