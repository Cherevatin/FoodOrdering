using System;

namespace FoodOrdering.Presentation.ViewModels.Menu
{
    public class GotAllMenusViewModel
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool ReadyToOrder { get; set; }
    }
}
