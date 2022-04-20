using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodOrdering.Application.Dtos.Menu;

namespace FoodOrdering.Application.Services.MenuService
{
    public interface IMenuService
    {
        Task<IEnumerable<GotAllMenusDto>> GetAllMenusAsync();

        Task<GotMenuDetailsDto> GetMenuDetailsAsync(Guid id);

        Task<GotMenuDto> GetMenuAllInfoAsync(Guid id);

        Task<GotDishesDto> GetAllDishesAsync(Guid id);

        Task AddMenuAsync(AddMenuDto dto);

        Task UpdateMenuAsync(Guid id, EditMenuDto dto);

        Task AddDishToMenuAsync(Guid id, AddDishToMenuDto dto);

        Task DeleteMenuAsync(Guid id);
    }
}
