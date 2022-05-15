using System;
using System.Collections.Generic;
using System.Linq;

using FoodOrdering.Domain.Common;
using FoodOrdering.Domain.Exception;

namespace FoodOrdering.Domain.Aggregates.BasketAggregate
{
    public class Basket : BaseEntity
    {
        private List<BasketItem> _basketItems = new();

        public Guid CustomerId { get; private set; }

        public IReadOnlyList<BasketItem> BasketItems => _basketItems;

        public Basket()
        {
            CustomerId = Guid.NewGuid();
        }

        public Basket(Guid employeeId)
        {
            CustomerId = employeeId;
        }

        public Basket AddItem(Guid dishId, Guid menuId)
        {
            _basketItems.Add(new BasketItem(dishId, menuId, Id));
            return this;
        }

        public Basket DeleteItem(Guid itemId)
        {
            var item = _basketItems.FirstOrDefault(p => p.DishId == itemId);
            if (item == null)
            {
                throw new DomainNotFoundException("Item not found");
            }
            _basketItems.Remove(item);
            return this;
        }

        public Basket UpdateItem(Guid itemId, int numberOfServings)
        {
            var item = _basketItems.FirstOrDefault(item => item.Id == itemId);
            item.UpdateNumberOfServings(numberOfServings);
            return this;
        }

        public Basket ClearItems()
        {
            _basketItems.Clear();
            return this;
        }

        public bool IsEmpty()
        {
            return !_basketItems.Any();
        }
        
    }
}
