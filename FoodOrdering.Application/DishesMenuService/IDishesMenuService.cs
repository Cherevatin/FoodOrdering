using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FoodOrdering.Domain.Entities;

namespace FoodOrdering.Application.DishesMenuService
{
    public interface IDishesMenuService
    {
        Task<IEnumerable<DishesMenu>> GetAllDishesMenusAsync();

        Task<DishesMenu> GetDishesMenuAsync(Guid id);

        Task CreateDishesMenuAsync(DishesMenu dish);

        Task UpdateDishesMenuAsync(DishesMenu dish);

        Task DeleteDishesMenuAsync(Guid id);
    }
}
