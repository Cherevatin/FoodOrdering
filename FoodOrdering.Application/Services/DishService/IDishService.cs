using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FoodOrdering.Application.Dtos.Dish;

namespace FoodOrdering.Application.Services.DishService
{
    public interface IDishService
    {
        Task<IEnumerable<GetAllDishesDto>> GetAll();

        Task<GetDishDto> Get(Guid id);

        Task Add(AddDishDto dto);

        Task Update(Guid id, UpdateDishDto dto);

        Task Delete(Guid id);


    }
}
