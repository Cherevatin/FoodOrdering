using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using FoodOrdering.Domain.Common;
using FoodOrdering.Domain.Aggregates.MenuAggregate;
using FoodOrdering.Application.Dtos.Menu;
using FoodOrdering.Application.Exception;

namespace FoodOrdering.Application.Services.MenuService
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public MenuService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<IEnumerable<GetAllMenusDto>> GetAll()
        {
            var menus = await _unitOfWork.Menus.GetAllWithDishes();

            List<GetAllMenusDto> menuDtoList = new();
  
            foreach (var menu in menus)
            {
                GetAllMenusDto dto = new()
                {
                    Id = menu.Id,
                    StartDate = menu.StartDate,
                    ExpirationDate = menu.ExpirationDate,
                    ReadyToOrder = menu.ReadyToOrder,
                    Dishes = _mapper.Map<List<GetAllMenusDto.Dish>>(menu.MenuItems
                        .Select(async p => await _unitOfWork.Dishes.Get(p.DishId))
                        .Select(t => t.Result))
                };
                menuDtoList.Add(dto);
            }
            return menuDtoList;
        }

        public async Task<GetMenuDto> GetMenu(Guid id)
        {
            var menu = await _unitOfWork.Menus.GetMenuWithDishes(id);

            if (menu == null)
            {
                throw new ApplicationNotFoundException("Menu not found");
            }

            GetMenuDto menuDto = new()
            {
                StartDate = menu.StartDate,
                ExpirationDate = menu.ExpirationDate,
                ReadyToOrder = menu.ReadyToOrder,
                Dishes = _mapper.Map<List<GetMenuDto.Dish>>(menu.MenuItems
                    .Select(async p => await _unitOfWork.Dishes.Get(p.DishId))
                    .Select(t => t.Result))
            };

            return menuDto;
        }

        public async Task Add(AddMenuDto menuDTO)
        {
            Menu menu = new(menuDTO.StartDate, menuDTO.ExpirationDate, menuDTO.ReadyToOrder, menuDTO.Dishes);

            await _unitOfWork.Menus.AddAsync(menu);
            await _unitOfWork.Save();
        }

        public async Task AddDish(Guid menuId, AddDishToMenuDto dto)
        {
            var menu = await _unitOfWork.Menus.Get(menuId);

            if (menu == null)
            {
                throw new ApplicationNotFoundException("Menu not found");
            }

            menu.AddDishes(dto.DishesId);

            _unitOfWork.Menus.Update(menu);
            await _unitOfWork.Save();
        }

        public async Task Update(Guid menuId, UpdateMenuDto dto)
        {
            var menuToUpdate = await _unitOfWork.Menus.GetMenuWithDishes(menuId);

            menuToUpdate.UpdateDetails(dto.StartDate, dto.ExpirationDate, dto.ReadyToOrder)
                .UpdateDishes(dto.Dishes);
            
            _unitOfWork.Menus.Update(menuToUpdate);
            await _unitOfWork.Save();
        }

        public async Task Delete(Guid id)
        {
            var menu = await _unitOfWork.Menus.Get(id);

            if (menu == null)
            {
                throw new ApplicationNotFoundException("Menu not found");
            }

            _unitOfWork.Menus.Remove(menu);
            await _unitOfWork.Save();
        }
    }
}
