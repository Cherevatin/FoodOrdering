using System;
using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.Presentation.ViewModels
{
    public class PlaceOrderViewModel
    {
        [Required]
        public DateTime ExecutionDate { get; set; }
    }
}
