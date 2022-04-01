using System;
using System.Collections.Generic;

using FoodOrdering.Domain.Entities;
using FoodOrdering.Domain.Interfaces;

namespace FoodOrdering.Application.DishesMenuService
{
    public class DishesMenuService : IDishesMenuService
    {
        private readonly IRepository<DishesMenu> _repository;
        public DishesMenuService(IRepository<DishesMenu> repository)
        {
            _repository = repository;
        }

        public void CreateDishesMenu(DishesMenu dishMenu)
        {
            _repository.Create(dishMenu);
        }

        public void DeleteDishesMenu(Guid id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<DishesMenu> GetAllDishesMenus()
        {
            return _repository.GetAll();
        }

        public DishesMenu GetDishesMenu(Guid id)
        {
            return _repository.Get(id);
        }

        public void UpdateDishesMenu(DishesMenu dish)
        {
            _repository.Update(dish);
        }
    }
}
