using System;
using System.Collections.Generic;

using FoodOrdering.Domain.Common;


namespace FoodOrdering.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public Guid EmployeeId { get; set; }


        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
