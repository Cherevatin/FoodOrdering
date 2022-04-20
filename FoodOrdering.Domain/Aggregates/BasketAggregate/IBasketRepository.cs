using FoodOrdering.Domain.Common;
using System;
using System.Threading.Tasks;

namespace FoodOrdering.Domain.Aggregates.BasketAggregate
{
    public interface IBasketRepository : IGenericRepository<Basket>
    {
        Task<bool> BasketExists(Guid id);

        Task<Basket> GetBasketById(Guid id);

    }
}
