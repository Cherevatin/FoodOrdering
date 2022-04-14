using System;
using System.Collections.Generic;

namespace FoodOrdering.Application.Dtos.DishMenu
{
    public class MenuDto
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool ReadyToOrder { get; set; }

        public List<Guid> Dishes { get; set; }
    }
}
