using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.Presentation.ViewModels.Menu
{
    public class AddDishToMenuViewModel
    {
        [Required]
        public List<Guid> DishesId { get; set; }
    }
}
