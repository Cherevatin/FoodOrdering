using System;

using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Entities
{
    public class Dish : BaseEntity
    {
        public string Ingredients { get; set; }

        public double Price { get; set; }

        public string ImageName { get; set; }

        //public Nutrients Nutrients { get; set; }

        public double? Proteins { get; set; }

        public double? Fats { get; set; }

        public double? Carbohydrates { get; set; }

        public double? Calories { get; set; }

        public double Weight { get; set; }


        public Guid? DishesMenuId { get; set; }

        public DishesMenu DishesMenu { get; set; }
    }
}
