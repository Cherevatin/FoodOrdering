using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrdering.Application.Dtos.DishMenu;
using FoodOrdering.Application.Infrastructure;
using FoodOrdering.Application.Interfaces;
using FoodOrdering.Domain.Entities;
using FoodOrdering.Domain.Interfaces;

namespace FoodOrdering.Application.Services
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
        public async Task<IEnumerable<GetAllMenusDto>> GetAllMenusAsync()
        {
            var menus = await _unitOfWork.Menus.GetAllAsync();

            if (menus is not null)
            {
                var menuDtoList = _mapper.Map<List<GetAllMenusDto>>(menus);

                return menuDtoList;
            }
            else
            {
                throw new Exception("Menus not found");
            }
        }

        public async Task<MenuDto> GetMenuAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("Menu ID not set");
            }
            else if (!await _unitOfWork.Menus.MenuExists(id))
            {
                throw new Exception("Menu does not exist");
            }

            Menu menu = await _unitOfWork.Menus.GetByIdAsync(id);

            MenuDto menuDto = _mapper.Map<Menu, MenuDto>(menu);

            return menuDto;
        }

        public async Task CreateMenuAsync(MenuDto menuDTO)
        {
            Menu menu = new()
            {
                Id = Guid.NewGuid(),
                StartDate = menuDTO.StartDate,
                ExpirationDate = menuDTO.ExpirationDate,
                ReadyToOrder = menuDTO.ReadyToOrder
            };
            
            menu.AddDish(menuDTO.Dishes);

            await _unitOfWork.Menus.AddAsync(menu);
            await _unitOfWork.Complete();
        }

        public async Task AddDishToMenu(AddDishToMenuDto addDishDto)
        {
            bool menuExists = await _unitOfWork.Menus.MenuExists(addDishDto.MenuId);

            if (menuExists)
            {
                await _unitOfWork.Menus.AddDishes(addDishDto.MenuId, addDishDto.DishesId);
                await _unitOfWork.Complete();
            }
            else
            {
                throw new Exception("Menu not found");
            }
        }

        public async Task UpdateMenuAsync(MenuDto menuDTO)
        {
            if (menuDTO == null)
            {
                throw new Exception("Menu not set");
            }
            else if (!await _unitOfWork.Menus.MenuExists(menuDTO.Id))
            {
                throw new Exception("Menu not found");
            }

            Menu menu = new()
            {
                Id = menuDTO.Id,
                StartDate = menuDTO.StartDate,
                ExpirationDate = menuDTO.ExpirationDate,
                ReadyToOrder = menuDTO.ReadyToOrder
            };

            menu.AddDish(menuDTO.Dishes);

            await _unitOfWork.Menus.MenuUpdate(menu);
            await _unitOfWork.Complete();
        }

        public async Task DeleteMenuAsync(Guid id)
        {
            if (await _unitOfWork.Menus.MenuExists(id))
            {
                var entity = await _unitOfWork.Menus.GetByIdAsync(id);
                _unitOfWork.Menus.Remove(entity);
                await _unitOfWork.Complete();
            }
            else
            {
                throw new Exception("Menu not found");
            }
        }



    }
}
