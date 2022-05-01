using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Aggregates.DishAggregate
{
    public class Dish : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }

        public string Ingredients { get; private set; }

        public double Price { get; private set; }

        public string ImageUrl { get; private set; }

        public Nutrients Nutrients { get; private set; }

        public Weight Weight { get; private set; }

        public Dish() { }

        public Dish(string name, 
            string ingredients, 
            double price, 
            double proteins, 
            double fats, 
            double carbohydrates, 
            double calories,
            double weightValue,
            int weightMeasurementUnit)
        {
            Name = name;
            Ingredients = ingredients;
            Price = price;
            Nutrients = new Nutrients(proteins, fats, carbohydrates, calories);
            Weight = new Weight(weightValue, weightMeasurementUnit);
        }

        public Dish UpdateName(string name)
        {
            Name = name;
            return this;
        }

        public Dish UpdatePrice(double price)
        {
            Price = price;
            return this;
        }

        public Dish UpdateIngredients(string ingredients)
        {
            Ingredients = ingredients;
            return this;
        }

        public Dish UpdateNutrients(double proteins, 
            double fats, 
            double carbohydrates, 
            double calories)
        {
            Nutrients = new Nutrients(proteins, fats, carbohydrates, calories);
            return this;
        }

        public Dish UpdateWeight(double weightValue, int weightMeasurementUnit)
        {
            Weight = new Weight(weightValue, weightMeasurementUnit);
            return this;
        }

    }
}
