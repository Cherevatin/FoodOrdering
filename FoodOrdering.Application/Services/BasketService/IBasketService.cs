using System;
using System.Threading.Tasks;

using FoodOrdering.Application.Dtos.Basket;

namespace FoodOrdering.Application.Services.BasketService
{
    public interface IBasketService
    {
        Task<GetBasketDto> Get(Guid basketId);
        
        Task Create(CreateBasketDto dto);

        Task AddDish(AddDishDto dto);

        Task UpdateNumberOfServings(Guid basketId, UpdateBasketItemDto dto);

        Task Clear(Guid basketId);

        Task DeleteDish(Guid basketId, Guid dishId);

        Task Delete(Guid basketId);
    }
}
