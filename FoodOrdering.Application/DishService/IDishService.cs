using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodOrdering.Domain.Entities;

namespace FoodOrdering.Application.DishService
{
    public interface IDishService
    {
        Task<IEnumerable<Dish>> GetAllDishesAsync();

        Task<Dish> GetDishAsync(Guid id);

        Task CreateDishAsync(Dish dish);

        Task UpdateDishAsync(Dish dish);

        Task DeleteDishAsync(Guid id);
    }
}
