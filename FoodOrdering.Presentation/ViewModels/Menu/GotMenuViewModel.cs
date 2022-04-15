using System;
using System.Collections.Generic;

namespace FoodOrdering.Presentation.ViewModels.Menu
{
    public class GotMenuViewModel
    {
        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool ReadyToOrder { get; set; }

        public List<Guid> Dishes { get; set; }
    }
}
