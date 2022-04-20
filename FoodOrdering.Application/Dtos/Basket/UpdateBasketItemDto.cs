using System;

namespace FoodOrdering.Application.Dtos.Basket
{
    public class UpdateBasketItemDto
    {
        public Guid itemId { get; set; }

        public int NumberOfServings { get; set; }
    }
}
