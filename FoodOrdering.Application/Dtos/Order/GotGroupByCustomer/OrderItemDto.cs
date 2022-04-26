using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Application.Dtos.Order.GotGroupByCustomer
{
    public class OrderItemDto
    {
        public Guid OrderItemId { get; set; }

        public Guid DishId { get; private set; }

        public string DishTitle { get; private set; }

        public double DishPrice { get; private set; }

        public int Units { get; private set; }
    }
}
