using System;
using System.Collections.Generic;

namespace FoodOrdering.Application.Dtos.Basket
{
    public class AddDishDto
    {
        public Guid DishId { get; set; }

        public Guid MenuId { get; set; }

        public Guid BasketId { get; set; }
    }
}
