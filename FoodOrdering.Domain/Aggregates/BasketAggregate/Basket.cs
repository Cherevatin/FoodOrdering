using System;
using System.Collections.Generic;
using System.Linq;
using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Aggregates.BasketAggregate
{
    public class Basket : BaseEntity
    {
        public Guid CustomerId { get; private set; }

        public ICollection<BasketItem> BasketItems { get; private set; } = new List<BasketItem>();

        public Basket()
        {
            Id = Guid.NewGuid();
            CustomerId = Guid.NewGuid();
        }

        public Basket(Guid employeeId)
        {
            CustomerId = employeeId;
        }

        public void AddItem(Guid dishId, Guid menuId)
        {
            BasketItems.Add(new BasketItem(dishId, menuId, Id));
        }

        public void DeleteItem(Guid itemId)
        {
            var item = BasketItems.FirstOrDefault(p => p.DishId == itemId);
            if (item is not null)
            {
                BasketItems.Remove(item);
            }
        }
        public BasketItem GetItem(Guid itemId)
        {
            return BasketItems.FirstOrDefault(p => p.Id == itemId);
        }

        public void UpdateItem(BasketItem item)
        {
            DeleteItem(item.Id);
            BasketItems.Add(item);
        }

        public void ClearItems()
        {
            BasketItems.Clear();
        }

        public bool IsNotEmpty() => BasketItems.Any();
        
    }
}
