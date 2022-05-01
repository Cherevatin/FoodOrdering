using System;

using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Aggregates.MenuAggregate
{
    public class MenuItem : BaseEntity
    {
        public Guid MenuId { get; private set; }

        public Guid DishId { get; private set; }

        public MenuItem(Guid menuId, Guid dishId)
        {
            MenuId = menuId;
            DishId = dishId;
        }
    }


}
