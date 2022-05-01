using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Aggregates.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        public Guid DishId { get; private set; }

        public string DishTitle { get; private set; }

        public double DishPrice { get; private set; }

        public int Units { get; private set; }

        public OrderItem(Guid dishId, string dishTitle, double dishPrice, int units)
        {
            DishId = dishId;
            DishTitle = dishTitle;
            DishPrice = dishPrice;
            Units = units;
        }
    }
}
