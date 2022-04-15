using System;

namespace FoodOrdering.Domain.Entities
{
    public class MenuDish 
    {
        public Guid MenuId { get; private set; }

        public Guid DishId { get; private set; }
        
        public Menu Menu { get; private set; }

        public Dish Dish { get; private set; }

        public MenuDish(Guid menuId, Guid dishId)
        {
            MenuId = menuId;
            DishId = dishId;
        }
    }


}
