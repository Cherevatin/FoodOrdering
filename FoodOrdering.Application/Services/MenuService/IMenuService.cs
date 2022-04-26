using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodOrdering.Application.Dtos.Menu;

namespace FoodOrdering.Application.Services.MenuService
{
    public interface IMenuService
    {
        Task<IEnumerable<GotAllMenusDto>> GetAll();

        Task<GotMenuDetailsDto> GetMenuDetails(Guid id);

        Task<GotMenuDto> GetMenuAllInfo(Guid id);

        Task<GotDishesDto> GetAllDishes(Guid id);

        Task Add(AddMenuDto dto);

        Task AddDish(Guid id, AddDishToMenuDto dto);

        Task Update(Guid id, EditMenuDto dto);

        Task Delete(Guid id);
    }
}
