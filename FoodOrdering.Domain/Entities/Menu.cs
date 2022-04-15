using System;
using System.Collections.Generic;
using System.Linq;
using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Entities
{
    public class Menu : BaseEntity
    {
        public DateTime StartDate { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public bool ReadyToOrder { get; private set; }

        public ICollection<MenuDish> Dishes { get; private set; } 
        
        public Menu() { }

        public Menu(DateTime startDate, DateTime expirationDate, bool readyToOrder, List<Guid> dishesId)
        {
            Dishes = new List<MenuDish>();
            StartDate = startDate;
            ExpirationDate = expirationDate;
            ReadyToOrder = readyToOrder;
            AddDishes(dishesId);
        }

        public void AddDish(Guid dishId)
        {
            Dishes.Add(new MenuDish(this.Id, dishId));
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

            Dishes.Clear();
            Dishes = newMenu.Dishes;
        }
            
    }
}

