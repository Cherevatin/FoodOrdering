using System;
using System.Collections.Generic;

namespace FoodOrdering.Presentation.ViewModels.Menu
{
    public class GetAllMenusViewModel
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool ReadyToOrder { get; set; }

        public List<Dish> Dishes { get; set; }

        public class Dish
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

            public int WeightMeasurementUnit { get; set; }
        }
    }
}
