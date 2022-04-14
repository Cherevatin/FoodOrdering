using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Presentation.ViewModels.Menu
{
    public class AddDishToMenuViewModel
    {
        [Required]
        public List<Guid> DishesId { get; set; }
    }
}
