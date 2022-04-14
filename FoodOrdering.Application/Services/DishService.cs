using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrdering.Application.Dtos.Dish;
using FoodOrdering.Application.Interfaces;
using FoodOrdering.Domain.Entities;
using FoodOrdering.Domain.Interfaces;

namespace FoodOrdering.Application.Services
{
    public class DishService : IDishService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public DishService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateDishAsync(DishDto dishDTO)
        {
            Dish dish = new()
            {
                Name = dishDTO.Name,
                Ingredients = dishDTO.Ingredients,
                Price = dishDTO.Price,
                Nutrients = new Nutrients()
                {
                    Proteins = dishDTO.Proteins,
                    Fats = dishDTO.Fats,
                    Carbohydrates = dishDTO.Carbohydrates,
                    Calories = dishDTO.Calories
                },
                Weight = dishDTO.Weight
            };

            await _unitOfWork.Dishes.AddAsync(dish);
            await _unitOfWork.Complete();
        }

        public async Task UpdateDishAsync(DishDto dishDTO)
        {
            if (dishDTO == null)
            {
                throw new Exception("Dish not set");
            }
            else if (!await _unitOfWork.Dishes.DishExists(dishDTO.Id))
            {
                throw new Exception("Dish not found");
            }

            Dish dish = new()
            {
                Name = dishDTO.Name,
                Ingredients = dishDTO.Ingredients,
                Price = dishDTO.Price,
                Nutrients = new Nutrients()
                {
                    Proteins = dishDTO.Proteins,
                    Fats = dishDTO.Fats,
                    Carbohydrates = dishDTO.Carbohydrates,
                    Calories = dishDTO.Calories
                },
                Weight = dishDTO.Weight
            }; 
            
            try
            {
                _unitOfWork.Dishes.Update(dish);
                await _unitOfWork.Complete();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteDishAsync(Guid id)
        {
            bool exist = await _unitOfWork.Dishes.DishExists(id);

            if (exist)
            {
                var dish = await _unitOfWork.Dishes.GetByIdAsync(id);
                _unitOfWork.Dishes.Remove(dish);
                await _unitOfWork.Complete();
            }
            else
            {
                throw new Exception("Dish not found");
            }
        }

        public async Task<IEnumerable<GetAllDishesDto>> GetAllDishesAsync()
        { 
            var dishes = await _unitOfWork.Dishes.GetAllAsync();

            if (dishes is not null)
            {
                var dishDtoList = _mapper.Map<List<GetAllDishesDto>>(dishes);

                return dishDtoList;
            }
            else
            {
                throw new Exception("Dihes not found");
            }
        }

        public async Task<DishDto> GetDishAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("Dish ID not set");
            }
            else if (!await _unitOfWork.Dishes.DishExists(id))
            {
                throw new Exception("Dish not found");
            }

            Dish dish = await _unitOfWork.Dishes.GetByIdAsync(id);

            DishDto dishDTO = _mapper.Map<DishDto>(dish);

            return dishDTO;
        }
    }
}
