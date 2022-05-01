using System;
using System.Threading.Tasks;

using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Aggregates.DishAggregate
{
    public interface IDishRepository : IGenericRepository<Dish>
    {
        Task<bool> IsExist(Guid id);
    }
}
