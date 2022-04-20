using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.Presentation.ViewModels.Basket
{
    public class AddDishToBasketViewModel
    {

        [Required]
        public Guid DishId { get; set; }

        [Required]
        public Guid MenuId { get; set; }

        public Guid BasketId { get; set; }
    }
}
