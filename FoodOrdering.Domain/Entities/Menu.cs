using System;
using System.Collections.Generic;
using System.Linq;
using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Entities
{
    public class Menu : BaseEntity
    {
        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool ReadyToOrder { get; set; }

        public ICollection<MenuDish> Dishes { get; set; } 
        
        public Menu()
        {
            Dishes = new List<MenuDish>();
        }

        public void AddDish(Guid dishId)
        {
            Dishes.Add(new MenuDish
            {
                MenuId = this.Id,
                DishId = dishId
            });
        }

        public void AddDish(List<Guid> dishesId)
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

