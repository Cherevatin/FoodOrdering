using System;
using System.Collections.Generic;

using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Aggregates.MenuAggregate
{
    public class Menu : BaseEntity, IAggregateRoot
    {
        private readonly List<MenuItem> _menuItems = new();
        
        public DateTime StartDate { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public bool ReadyToOrder { get; private set; }

        public IReadOnlyList<MenuItem> MenuItems => _menuItems;

        public Menu() { }

        public Menu(DateTime startDate, DateTime expirationDate, bool readyToOrder, List<Guid> dishesId)
        {
            StartDate = startDate;
            ExpirationDate = expirationDate;
            ReadyToOrder = readyToOrder;
            AddDishes(dishesId);
        }

        public void AddDish(Guid dishId)
        {
            _menuItems.Add(new MenuItem(Id, dishId));
        }

        public void AddDishes(List<Guid> dishesId)
        {
            dishesId.ForEach(dishId =>
            {
                AddDish(dishId);
            });
        }

        public Menu UpdateDetails(DateTime startDate, DateTime expirationDate, bool readyToOrder)
        {
            StartDate = startDate;
            ExpirationDate = expirationDate;
            ReadyToOrder = readyToOrder;
            return this;
        }

        public Menu UpdateDishes(List<Guid> dishesId)
        {
            _menuItems.Clear();
            AddDishes(dishesId);
            return this;
        }
    }
}

