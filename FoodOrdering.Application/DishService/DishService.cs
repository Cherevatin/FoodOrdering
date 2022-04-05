using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrdering.Application.DTO.Dish;
using FoodOrdering.Application.Infrastructure;
using FoodOrdering.Domain.Entities;
using FoodOrdering.Domain.Interfaces;

namespace FoodOrdering.Application.DishService
{
    public class DishService : IDishService
    {
        private readonly IAsyncRepository<Dish> _repository;

        public DishService(IAsyncRepository<Dish> repository)
        {
            _repository = repository;
        }
        public async Task CreateDishAsync(DishDTO dishDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DishDTO, Dish>());
            var mapper = new Mapper(config);

            Dish dish = mapper.Map<DishDTO, Dish>(dishDTO);

            await _repository.AddAsync(dish);
        }

        public async Task UpdateDishAsync(DishDTO dishDTO)
        {
            if (dishDTO == null)
            {
                throw new ValidationException("Dish not set", "");
            }
            else if (! await DishExists(dishDTO.Id))
            {
                throw new ValidationException("Dish not found","");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<DishDTO, Dish>());
            var mapper = new Mapper(config);

            Dish dish = mapper.Map<DishDTO, Dish>(dishDTO);

            await _repository.UpdateAsync(dish);
        }

        public async Task DeleteDishAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            
            if (entity == null){
                throw new ValidationException("Dish does't exists", "");
            }

            await _repository.RemoveAsync(entity);
        }

        public async Task<IEnumerable<GetAllDishesDTO>> GetAllDishesAsync()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Dish, GetAllDishesDTO>()).CreateMapper();
            var dishDtoList = mapper.Map<IEnumerable<Dish>, List<GetAllDishesDTO>>(await _repository.GetAllAsync());
            
            return dishDtoList;
        }

        public async Task<DishDTO> GetDishAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ValidationException("Dish ID not set","");
            }

            var dish = await _repository.GetByIdAsync(id);

            if (!await DishExists(id))
            {
                throw new ValidationException("Dish does not exist","");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Dish, DishDTO>());
            var mapper = new Mapper(config);

            DishDTO dishDTO = mapper.Map<Dish, DishDTO>(await _repository.GetByIdAsync(id));

            return dishDTO;
        }

        public async Task<bool> DishExists(Guid id) => await _repository.IsExists(id);
    }
}
