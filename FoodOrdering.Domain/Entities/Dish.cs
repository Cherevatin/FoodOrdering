using System.Collections.Generic;
using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Entities
{
    public class Dish : BaseEntity
    {
        public string Name { get; private set; }

        public string Ingredients { get; private set; }

        public double Price { get; private set; }

        public string ImageName { get; private set; }

        public Nutrients Nutrients { get; private set; }

        public double Weight { get; private set; }

        public ICollection<MenuDish> Dishes { get; private set; } 
        public Dish(){}

        public Dish(string name, string ingredients, double price, Nutrients nutrients, double weight)
        {
            Name = name;
            Ingredients = ingredients;
            Price = price;
            Nutrients = new Nutrients(nutrients);
            Weight = weight;
            Dishes = new List<MenuDish>();
        }

        public void Update(Dish dish)
        {
            Name = dish.Name;
            Ingredients = dish.Ingredients;
            Price = dish.Price;
            Nutrients = dish.Nutrients;
            Weight = dish.Weight;
        }

    }
}
