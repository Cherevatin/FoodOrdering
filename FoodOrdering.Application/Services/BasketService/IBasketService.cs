using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodOrdering.Application.Dtos.Basket;
using FoodOrdering.Domain.Aggregates.BasketAggregate;

namespace FoodOrdering.Application.Services.BasketService
{
    public interface IBasketService
    {
        Task<GotBasketDto> GetBasket(Guid basketId);

        Task<IEnumerable<Basket>> GetAll();

        Task CreateBasketAsync(CreateBasketDto dto);

        Task AddDishAsync(AddDishDto dto);

        Task UpdateNumberOfServings(Guid basketId, UpdateBasketItemDto dto);

        Task DeleteDishAsync(Guid basketId, Guid dishId);
        
        Task DeleteBasket(Guid basketId);

    }
}
