using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.Domain.Entities
{
    [Owned]
    public class Nutrients
    {
        public double? Proteins { get; private set; }

        public double? Fats { get; private set; }

        public double? Carbohydrates { get; private set; }

        public double? Calories { get; private set; }

        public Nutrients(double? proteins, double? fats, double? carbohydrates, double? calories)
        {
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
            Calories = calories;
        }

        public Nutrients(Nutrients nutrients)
        {
            Proteins = nutrients.Proteins;
            Fats = nutrients.Fats;
            Carbohydrates = nutrients.Carbohydrates;
            Calories = nutrients.Calories;
        }

    }
}
