using System;
using System.Threading.Tasks;

using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Aggregates.BasketAggregate
{
    public interface IBasketRepository : IGenericRepository<Basket>
    {
        Task<bool> BasketExists(Guid id);

        Task<Basket> GetBasketById(Guid id);

    }
}
