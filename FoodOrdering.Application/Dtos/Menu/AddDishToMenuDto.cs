using System;
using System.Collections.Generic;

namespace FoodOrdering.Application.Dtos.Menu
{
    public class AddDishToMenuDto
    {
        public List<Guid> DishesId { get; set; }
    }
}
