using System;
using System.Collections.Generic;

namespace FoodOrdering.Application.Dtos.Menu
{
    public class GotDishesDto
    {
        public Dictionary<Guid, string> Dishes { get; set; } = new Dictionary<Guid, string>();
    }
}