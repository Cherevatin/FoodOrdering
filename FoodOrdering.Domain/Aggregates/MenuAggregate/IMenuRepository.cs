using System;
using System.Threading.Tasks;
using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Aggregates.MenuAggregate
{
    public interface IMenuRepository : IGenericRepository<Menu>
    {
        Task<bool> IsExist(Guid id);

        Task<Menu> GetMenuWithDishesById(Guid id);
    }
}
