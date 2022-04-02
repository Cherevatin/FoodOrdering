using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task CreateDishAsync(Dish dish)
        {
            await _repository.AddAsync(dish);
        }

        public async Task UpdateDishAsync(Dish dish)
        {
            await _repository.UpdateAsync(dish);
        }

        public async Task DeleteDishAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.RemoveAsync(entity);
        }

        public async Task<IEnumerable<Dish>> GetAllDishesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Dish> GetDishAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
