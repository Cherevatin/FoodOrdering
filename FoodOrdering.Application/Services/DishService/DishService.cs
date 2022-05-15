using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using FoodOrdering.Domain.Common;
using FoodOrdering.Domain.Aggregates.DishAggregate;
using FoodOrdering.Application.Dtos.Dish;
using FoodOrdering.Application.Exception;

namespace FoodOrdering.Application.Services.DishService
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
        
        public async Task<IEnumerable<GetAllDishesDto>> GetAll()
        {
            var dishes = await _unitOfWork.Dishes.GetAllAsync();

            var dishDtoList = _mapper.Map<List<GetAllDishesDto>>(dishes);

            return dishDtoList;
        }
        
        public async Task<GetDishDto> Get(Guid id)
        {
            var dish = await _unitOfWork.Dishes.Get(id);

            if (dish == null)
            {
                throw new ApplicationNotFoundException("Dish not found");
            }

            var dishDTO = _mapper.Map<GetDishDto>(dish);

            return dishDTO;
        }
        
        public async Task Add(AddDishDto dishDTO)
        {
            Dish dish = new(dishDTO.Name, 
                dishDTO.Ingredients, 
                dishDTO.Price, 
                dishDTO.Proteins, 
                dishDTO.Fats, 
                dishDTO.Carbohydrates, 
                dishDTO.Calories,
                dishDTO.WeightValue,
                dishDTO.WeightMeasurementUnit);

            await _unitOfWork.Dishes.AddAsync(dish);
            await _unitOfWork.Save();
        }

        public async Task Update(Guid id, UpdateDishDto dto)
        {
            var DishToUpdate = await _unitOfWork.Dishes.Get(id);

            if (DishToUpdate == null)
            {
                throw new ApplicationNotFoundException("Dish not found");
            }

            DishToUpdate.UpdateName(dto.Name)
                .UpdateIngredients(dto.Ingredients)
                .UpdatePrice(dto.Price)
                .UpdateNutrients(dto.Proteins, dto.Fats, dto.Carbohydrates, dto.Calories)
                .UpdateWeight(dto.WeightValue, dto.WeightMeasurementUnit);

            _unitOfWork.Dishes.Update(DishToUpdate);
            await _unitOfWork.Save();
        }

        public async Task Delete(Guid id)
        {
            var dish = await _unitOfWork.Dishes.Get(id);

            if (dish == null)
            {
                throw new ApplicationNotFoundException("Dish not found");
            }

            _unitOfWork.Dishes.Remove(dish);
            await _unitOfWork.Save();
        }


    }
}
