﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrdering.Application.Dtos.Menu;
using FoodOrdering.Domain.Aggregates.MenuAggregate;
using FoodOrdering.Domain.Common;

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
        public async Task<IEnumerable<GotAllMenusDto>> GetAll()
        {
            var menus = await _unitOfWork.Menus.GetAllAsync();

            if (menus is not null)
            {
                var menuDtoList = _mapper.Map<List<GotAllMenusDto>>(menus);

                return menuDtoList;
            }
            else
            {
                throw new Exception("Menus not found");
            }
        }

        public async Task<GotMenuDetailsDto> GetMenuDetails(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("Menu ID not set");
            }
            else if (!await _unitOfWork.Menus.IsExist(id))
            {
                throw new Exception("Menu does not exist");
            }

            Menu menu = await _unitOfWork.Menus.GetByIdAsync(id);

            GotMenuDetailsDto dto = _mapper.Map<GotMenuDetailsDto>(menu);

            return dto;
        }

        public async Task<GotDishesDto> GetAllDishes(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("Menu ID not set");
            }
            else if (!await _unitOfWork.Menus.IsExist(id))
            {
                throw new Exception("Menu does not exist");
            }

            Menu menu = await _unitOfWork.Menus.GetMenuWithDishesById(id);

            GotDishesDto menuDishesDto = new();

            foreach (var dishLink in menu.MenuItems)
            {
                var dish = await _unitOfWork.Dishes.GetByIdAsync(dishLink.DishId);
                menuDishesDto.Dishes.Add(dish.Id, dish.Name);
            }

            return menuDishesDto;
        }

        public async Task Add(AddMenuDto menuDTO)
        {
            Menu menu = new(menuDTO.StartDate, menuDTO.ExpirationDate, menuDTO.ReadyToOrder, menuDTO.Dishes);

            await _unitOfWork.Menus.AddAsync(menu);
            await _unitOfWork.Save();
        }

        public async Task AddDish(Guid menuId, AddDishToMenuDto dto)
        {
            bool menuExists = await _unitOfWork.Menus.IsExist(menuId);

            if (menuExists)
            {
                Menu menu = await _unitOfWork.Menus.GetByIdAsync(menuId);
                _unitOfWork.Menus.Update(menu);
                menu.AddDishes(dto.DishesId);

                await _unitOfWork.Save();
            }
            else
            {
                throw new Exception("Menu not found");
            }
        }

        public async Task Update(Guid menuId, EditMenuDto dto)
        {
            if (dto == null)
            {
                throw new Exception("Menu not set");
            }
            else if (!await _unitOfWork.Menus.IsExist(menuId))
            {
                throw new Exception("Menu not found");
            }

            Menu newMenu = new(dto.StartDate, dto.ExpirationDate, dto.ReadyToOrder, dto.Dishes);

            //Menu oldMenu1 = await _unitOfWork.Menus.GetMenuWithDishesById(menuDTO.Id);?????? WHY
            //Menu oldMenu = await _unitOfWork.Menus.GetByIdAsync(menuId);

            Menu oldMenu = await _unitOfWork.Menus.GetMenuWithDishesById(menuId);
            _unitOfWork.Menus.Update(oldMenu);
            oldMenu.Update(newMenu);

            await _unitOfWork.Save();
        }

        public async Task Delete(Guid id)
        {
            if (await _unitOfWork.Menus.IsExist(id))
            {
                var entity = await _unitOfWork.Menus.GetByIdAsync(id);
                _unitOfWork.Menus.Remove(entity);
                await _unitOfWork.Save();
            }
            else
            {
                throw new Exception("Menu not found");
            }
        }

        public async Task<GotMenuDto> GetMenuAllInfo(Guid menuId)
        {
            if (!await _unitOfWork.Menus.IsExist(menuId))
            {
                throw new Exception("Menu not found");
            }

            Menu menu = await _unitOfWork.Menus.GetMenuWithDishesById(menuId);

            GotMenuDto dto = new()
            {
                StartDate = menu.StartDate,
                ExpirationDate = menu.ExpirationDate,
                ReadyToOrder = menu.ReadyToOrder
            };

            foreach (var dishLink in menu.MenuItems)
            {
                dto.Dishes.Add(dishLink.DishId);
            }

            return dto;
        }
    }
}