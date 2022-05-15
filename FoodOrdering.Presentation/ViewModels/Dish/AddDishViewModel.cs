using System;
using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.Presentation.ViewModels.Dish
{
    public class AddDishViewModel
    {

        [Required(ErrorMessage = "Please enter dish name!")]
        [StringLength(100)]
        [Display(Name = "Dish name")]
        public string Name { get; set; }

        [StringLength(256)]
        [Display(Name = "List of ingredients")]
        public string Ingredients { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Invalid price")]
        [Display(Name = "Price")]
        public double Price { get; set; }

        //[Display(Name = "Dish image")]
        //public IFormFile DishImage { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Please enter positive number")]
        [Display(Name = "Amount of proteins")]
        public double? Proteins { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Please enter positive number")]
        [Display(Name = "Amount of fats")]
        public double? Fats { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Please enter positive number")]
        [Display(Name = "Amount of carbohydrates")]
        public double? Carbohydrates { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Please enter positive number")]
        [Display(Name = "Amount of calories")]
        public double? Calories { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter positive number")]
        [Display(Name = "Dish weight")]
        public double Weight { get; set; }

        [Required]
        [Display(Name = "Dish weight measurement unit")]
        public int WeightMeasurementUnit { get; set; }
    }
}
