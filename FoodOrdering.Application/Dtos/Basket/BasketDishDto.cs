using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Application.Dtos.Basket
{
    public class BasketDishDto
    {
        public Guid DishId { get; set; }

        public string DishTitle { get; set; }
    }
}
