using System;

using FoodOrdering.Domain.Entities;
using FoodOrdering.Domain.Interfaces;

namespace FoodOrdering.Application.DishService
{
    public class DishService : IDishService
    {
        private readonly IRepository<Dish> _repository;

        public DishService(IRepository<Dish> repository)
        {
            _repository = repository;
        }
        public void CreateDish(Dish dish)
        {
            _repository.Create(dish);
        }

        public void UpdateDish(Dish dish)
        {
            _repository.Update(dish);
        }

        public void DeleteDish(Guid id)
        {
            _repository.Delete(id);
        }

        //public IEnumerable<Dish> GetAllDishes()
        //{
        //    return _repository.GetAll();
        //}

        //public Dish GetDish(Guid id)
        //{
        //    return _repository.Get(id);
        //}   
    }
}
