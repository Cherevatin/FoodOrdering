using System;
using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.Presentation.ViewModels.Basket
{
    public class CreateBasketViewModel
    {
        [Required]
        public Guid EmployeeId { get; set; }
    }
}
