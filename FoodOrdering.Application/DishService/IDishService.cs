using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodOrdering.Application.DTO.Dish;

namespace FoodOrdering.Application.DishService
{
    public interface IDishService
    {
        Task<IEnumerable<GetAllDishesDTO>> GetAllDishesAsync();

        Task<DishDTO> GetDishAsync(Guid id);

        Task CreateDishAsync(DishDTO dishDTO);

        Task UpdateDishAsync(DishDTO dishDTO);

        Task DeleteDishAsync(Guid id);

        Task<bool> DishExists(Guid id); 
    }
}
