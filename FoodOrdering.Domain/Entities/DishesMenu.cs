using System;
using System.Collections.Generic;

using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Entities
{
    public class DishesMenu : BaseEntity
    {
        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool ReadyToOrder { get; set; }


        public ICollection<Dish> Dishes { get; set; }
    }
}
