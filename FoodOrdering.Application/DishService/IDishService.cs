using System;

using FoodOrdering.Domain.Entities;

namespace FoodOrdering.Application.DishService
{
    public interface IDishService
    {
        //IEnumerable<Dish> GetAllDishes();

        //Dish GetDish(Guid id);

        void CreateDish(Dish dish);

        void UpdateDish(Dish dish);

        void DeleteDish(Guid id);
    }
}
