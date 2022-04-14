using FoodOrdering.Presentation.ViewModels.Dish;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.Presentation.ViewModels.Menu
{
    public class AddMenuViewModel
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public bool ReadyToOrder { get; set; }

        [Required]
        public List<Guid> Dishes { get; set; }
    }
}
