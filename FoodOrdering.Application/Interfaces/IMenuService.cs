using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodOrdering.Application.Dtos.DishMenu;
using FoodOrdering.Domain.Entities;

namespace FoodOrdering.Application.Interfaces
{
    public interface IMenuService
    {
        Task<IEnumerable<GetAllMenusDto>> GetAllMenusAsync();

        Task<MenuDto> GetMenuAsync(Guid id);

        Task CreateMenuAsync(MenuDto menu);

        Task UpdateMenuAsync(MenuDto menu);

        Task AddDishToMenu(AddDishToMenuDto dish);

        Task DeleteMenuAsync(Guid id);
    }
}
