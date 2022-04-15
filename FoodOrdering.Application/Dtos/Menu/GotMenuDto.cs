using System;
using System.Collections.Generic;

namespace FoodOrdering.Application.Dtos.Menu
{
    public class GotMenuDto
    {
        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool ReadyToOrder { get; set; }

        public List<Guid> Dishes { get; set; } = new List<Guid>();
    }
}
