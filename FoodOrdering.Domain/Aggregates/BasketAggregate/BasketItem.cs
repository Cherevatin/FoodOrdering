using System;

using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Aggregates.BasketAggregate
{
    public class BasketItem : BaseEntity
    {
        public Guid DishId { get; private set; }

        public Guid MenuId { get; private set; }

        public Guid BasketId { get; private set; }

        public int NumberOfServings { get; private set; }

        public BasketItem(Guid dishId, Guid menuId, Guid basketId)
        {
            DishId = dishId;
            MenuId = menuId;
            BasketId = basketId;
            NumberOfServings = 1;
        }

        public void UpdateNumberOfServings(int newNumber)
        {
            if (newNumber > 0)
            {
                NumberOfServings = newNumber;
            }
        }
    }
}
