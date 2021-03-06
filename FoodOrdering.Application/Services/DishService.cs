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
        public async Task CreateDishAsync(AddDishDto dishDTO)
        {
            Nutrients nutrients = new(dishDTO.Proteins, dishDTO.Fats, dishDTO.Carbohydrates, dishDTO.Calories);
            Dish dish = new(dishDTO.Name, dishDTO.Ingredients, dishDTO.Price, nutrients, dishDTO.Weight);

            await _unitOfWork.Dishes.AddAsync(dish);
            await _unitOfWork.Save();
        }

        public async Task UpdateDishAsync(Guid id, EditDishDto dto)
        {
            if (dto == null)
            {
                throw new Exception("Dish not set");
            }
            else if (!await _unitOfWork.Dishes.DishExists(id))
            {
                throw new Exception("Dish not found");
            }


            Nutrients nutrients = new(dto.Proteins,dto.Fats,dto.Carbohydrates,dto.Calories);
            Dish newDish = new(dto.Name,dto.Ingredients,dto.Price,nutrients,dto.Weight);

            Dish oldDish = await _unitOfWork.Dishes.GetByIdAsync(id);
            
            try
            {
                _unitOfWork.Dishes.ToModifiedState(oldDish);
                oldDish.Update(newDish);
                await _unitOfWork.Save();
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
                await _unitOfWork.Save();
            }
            else
            {
                throw new Exception("Dish not found");
            }
        }

        public async Task<IEnumerable<GotAllDishesDto>> GetAllDishesAsync()
        { 
            var dishes = await _unitOfWork.Dishes.GetAllAsync();

            if (dishes is not null)
            {
                var dishDtoList = _mapper.Map<List<GotAllDishesDto>>(dishes);

                return dishDtoList;
            }
            else
            {
                throw new Exception("Dihes not found");
            }
        }

        public async Task<GotDishDto> GetDishAsync(Guid id)
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

            GotDishDto dishDTO = _mapper.Map<GotDishDto>(dish);

            return dishDTO;
        }
    }
}
