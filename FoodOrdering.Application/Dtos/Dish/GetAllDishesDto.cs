using System;

namespace FoodOrdering.Application.Dtos.Dish
{
    public class GetAllDishesDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Ingredients { get; set; }

        public double Price { get; set; }

        public double Proteins { get; set; }

        public double Fats { get; set; }

        public double Carbohydrates { get; set; }

        public double Calories { get; set; }

        public double WeightValue { get; set; }

        public string WeightMeasurementUnit { get; set; }
    }
}
