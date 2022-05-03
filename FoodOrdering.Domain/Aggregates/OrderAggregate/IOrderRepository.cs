using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Aggregates.OrderAggregate
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetOrder(Guid id);

        Task<ICollection<Order>> GetAll(Guid id);
    }
}
