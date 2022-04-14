using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Presentation.ViewModels.Menu
{
    public class EditMenuViewModel
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
