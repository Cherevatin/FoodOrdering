using System;

using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Entities
{
    public class BasketItem : BaseEntity
    {
        public Guid DishId { get; set; }

        public Guid MenuId { get; set; }


        public Guid BasketId { get; set; }

        public Basket Basket { get; set; }
    }
}
