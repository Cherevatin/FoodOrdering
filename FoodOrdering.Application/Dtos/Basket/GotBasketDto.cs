using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Application.Dtos.Basket
{
    public class GotBasketDto
    {
        public Guid CustomerId { get; set; }

        public DateTime StartDate { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public Dictionary<Guid, BasketMenuDto> Items { get; set; } = new();

    }
}
