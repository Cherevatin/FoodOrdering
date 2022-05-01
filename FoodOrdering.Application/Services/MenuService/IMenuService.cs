using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FoodOrdering.Application.Dtos.Menu;

namespace FoodOrdering.Application.Services.MenuService
{
    public interface IMenuService
    {
        Task<IEnumerable<GetAllMenusDto>> GetAll();

        Task<GetMenuDto> GetMenu(Guid id);

        Task Add(AddMenuDto dto);

        Task AddDish(Guid id, AddDishToMenuDto dto);

        Task Update(Guid id, UpdateMenuDto dto);

        Task Delete(Guid id);
    }
}
