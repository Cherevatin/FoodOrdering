using System;
using System.Collections.Generic;

using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T Get(Guid id);

        void Create(T entity);

        void Update(T entity);

        void Delete(Guid id);

        void Save();
    }
}
