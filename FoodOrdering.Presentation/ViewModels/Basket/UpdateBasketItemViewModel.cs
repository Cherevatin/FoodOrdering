using System;
using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.Presentation.ViewModels.Basket
{
    public class UpdateBasketItemViewModel
    {
        [Required]
        public Guid itemId { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Invalid number")]
        public int NumberOfServings { get; set; }
    }
}
