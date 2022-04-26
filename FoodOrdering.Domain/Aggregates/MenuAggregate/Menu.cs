using System;
using System.Collections.Generic;
using System.Linq;
using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Aggregates.MenuAggregate
{
    public class Menu : BaseEntity
    {
        public DateTime StartDate { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public bool ReadyToOrder { get; private set; }

        public ICollection<MenuItem> MenuItems { get; private set; } = new List<MenuItem>();

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
            MenuItems.Add(new MenuItem(Id, dishId));
        }

        public void AddDishes(List<Guid> dishesId)
        {
            dishesId.ForEach(dishId =>
            {
                AddDish(dishId);
            });
        }

        public void Update(Menu newMenu)
        {
            StartDate = newMenu.StartDate;
            ExpirationDate = newMenu.ExpirationDate;
            ReadyToOrder = newMenu.ReadyToOrder;

            MenuItems.Clear();
            MenuItems = newMenu.MenuItems;
        }

    }
}

