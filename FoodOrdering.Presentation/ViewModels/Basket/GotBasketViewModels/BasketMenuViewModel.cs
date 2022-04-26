using System;
using System.Collections.Generic;

namespace FoodOrdering.Presentation.ViewModels.Basket.GotBasketViewModels
{
    public class BasketMenuViewModel
    {
        public DateTime StartDate { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public List<BasketDishViewModel> Dishes { get; set; }
    }
}
