using System;

namespace FoodOrdering.Domain.Entities
{
    public class MenuDish 
    {
        public Guid DishId { get; set; }
        
        public Guid MenuId { get; set; }


        public Dish Dish { get; set; }

        public Menu Menu { get; set; }

    }


}
