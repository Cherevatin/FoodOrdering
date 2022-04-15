using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Presentation.ViewModels.Menu
{
    public class GotMenuDetailsViewModel
    {
        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool ReadyToOrder { get; set; }
    }
}
