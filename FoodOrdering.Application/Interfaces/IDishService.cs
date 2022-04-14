using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodOrdering.Application.Dtos.Dish;

namespace FoodOrdering.Application.Interfaces
{
    public interface IDishService
    {
        Task<IEnumerable<GetAllDishesDto>> GetAllDishesAsync();

        Task<DishDto> GetDishAsync(Guid id);

        Task CreateDishAsync(DishDto dishDTO);

        Task UpdateDishAsync(DishDto dishDTO);

        Task DeleteDishAsync(Guid id);
    }
}
