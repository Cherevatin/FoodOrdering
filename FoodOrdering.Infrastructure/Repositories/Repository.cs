using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using FoodOrdering.Domain.Common;
using FoodOrdering.Domain.Interfaces;

namespace FoodOrdering.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly FoodOrderingContext _foodOrderingContext;
        private DbSet<T> _entities;

        public Repository(FoodOrderingContext foodOrderingContext)
        {
            _foodOrderingContext = foodOrderingContext;
            _entities = _foodOrderingContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T Get(Guid id)
        {
            return _entities.SingleOrDefault(x => x.Id == id);
        }

        public void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            _foodOrderingContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Update(entity);
            _foodOrderingContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = _entities.Find(id);
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            _foodOrderingContext.SaveChanges();
        }

        public void Save()
        {
            _foodOrderingContext.SaveChanges();
        }
    }
}
