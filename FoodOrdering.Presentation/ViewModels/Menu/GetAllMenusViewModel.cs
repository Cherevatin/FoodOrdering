using System;

namespace FoodOrdering.Presentation.ViewModels.Menu
{
    public class GetAllMenusViewModel
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool ReadyToOrder { get; set; }
    }
}
