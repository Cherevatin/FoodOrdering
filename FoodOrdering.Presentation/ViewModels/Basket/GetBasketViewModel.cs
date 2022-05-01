using System;
using System.Collections.Generic;

namespace FoodOrdering.Presentation.ViewModels.Basket
{
    public class GetBasketViewModel
    {
        public Guid CustomerId { get; set; }

        public List<Menu> Menus { get; set; }

        public class Menu
        {
            public Guid MenuId { get; set; }

            public DateTime StartDate { get; set; }

            public DateTime ExpirationDate { get; set; }

            public List<Dish> Dishes { get; set; }
        }

        public class Dish
        {
            public Guid DishId { get; set; }

            public string DishTitle { get; set; }
        }
    }
}
