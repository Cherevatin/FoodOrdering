using System;
using System.Collections.Generic;

using FoodOrdering.Domain.Entities;

namespace FoodOrdering.Application.DishesMenuService
{
    public interface IDishesMenuService
    {
        IEnumerable<DishesMenu> GetAllDishesMenus();

        DishesMenu GetDishesMenu(Guid id);

        void CreateDishesMenu(DishesMenu dish);

        void UpdateDishesMenu(DishesMenu dish);

        void DeleteDishesMenu(Guid id);
    }
}
