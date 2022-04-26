using System;
using System.Collections.Generic;

namespace FoodOrdering.Presentation.ViewModels.Basket.GotBasketViewModels
{
    public class GotBasketViewModel
    {
        public Guid CustomerId { get; set; }

        public Dictionary<Guid, BasketMenuViewModel> Items { get; set; }
    }
}
