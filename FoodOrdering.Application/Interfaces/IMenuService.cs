using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodOrdering.Application.Dtos.Menu;
using FoodOrdering.Domain.Entities;

namespace FoodOrdering.Application.Interfaces
{
    public interface IMenuService
    {
        Task<IEnumerable<GotAllMenusDto>> GetAllMenusAsync();

        Task<GotMenuDetailsDto> GetMenuDetails(Guid id);

        Task<GotMenuDto> GetMenuAllInfo(Guid id);

        Task<GotDishesDto> GetAllDishes(Guid id);

        Task CreateMenuAsync(AddMenuDto dto);

        Task UpdateMenuAsync(Guid id, EditMenuDto dto);

        Task AddDishToMenu(Guid id, AddDishToMenuDto dto);

        Task DeleteMenuAsync(Guid id);
    }
}
