using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Application.Dtos.Basket
{
    public class BasketMenuDto
    {
        public Guid MenuId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public List<BasketDishDto> Dishes { get; set; } = new();
    }
}
