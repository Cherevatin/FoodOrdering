using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FoodOrdering.Domain.Entities;
using FoodOrdering.Domain.Interfaces;

namespace FoodOrdering.Application.DishesMenuService
{
    public class DishesMenuService : IDishesMenuService
    {
        private readonly IAsyncRepository<DishesMenu> _repository;
        public DishesMenuService(IAsyncRepository<DishesMenu> repository)
        {
            _repository = repository;
        }

        public async Task CreateDishesMenuAsync(DishesMenu dishMenu)
        {
            await _repository.AddAsync(dishMenu);
        }

        public async Task DeleteDishesMenuAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.RemoveAsync(entity);
        }

        public async Task<IEnumerable<DishesMenu>> GetAllDishesMenusAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<DishesMenu> GetDishesMenuAsync(Guid id)
        {
             return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateDishesMenuAsync(DishesMenu dish)
        {
            await _repository.UpdateAsync(dish);
        }
    }
}
