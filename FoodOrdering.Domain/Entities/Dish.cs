using System.Collections.Generic;
using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Entities
{
    public class Dish : BaseEntity
    {
        public string Name { get; set; }

        public string Ingredients { get; set; }

        public double Price { get; set; }

        public string ImageName { get; set; }

        public Nutrients Nutrients { get; set; }

        public double Weight { get; set; }

        public ICollection<MenuDish> Dishes { get; set; } 

        public Dish()
        {
            Dishes = new List<MenuDish>();
        }
    }
}
