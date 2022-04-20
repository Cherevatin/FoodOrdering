using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodOrdering.Application.Dtos.Dish;

namespace FoodOrdering.Application.Services.DishService
{
    public interface IDishService
    {
        Task<IEnumerable<GotAllDishesDto>> GetAllDishesAsync();

        Task<GotDishDto> GetDishAsync(Guid id);

        Task AddDishAsync(AddDishDto dto);

        Task UpdateDishAsync(Guid id, EditDishDto dto);

        Task DeleteDishAsync(Guid id);


    }
}
