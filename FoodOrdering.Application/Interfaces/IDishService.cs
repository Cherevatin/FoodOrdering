using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodOrdering.Application.Dtos.Dish;

namespace FoodOrdering.Application.Interfaces
{
    public interface IDishService
    {
        Task<IEnumerable<GotAllDishesDto>> GetAllDishesAsync();

        Task<GotDishDto> GetDishAsync(Guid id);

        Task CreateDishAsync(AddDishDto dto);

        Task UpdateDishAsync(Guid id, EditDishDto dto);

        Task DeleteDishAsync(Guid id);

        
    }
}
