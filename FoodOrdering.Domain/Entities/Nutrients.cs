using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.Domain.Entities
{
    [Owned]
    public class Nutrients
    {
        public double? Proteins { get; set; }

        public double? Fats { get; set; }

        public double? Carbohydrates { get; set; }

        public double? Calories { get; set; }
    }
}
