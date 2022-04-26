using FoodOrdering.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Domain.Aggregates.OrderAggregate
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> Get(Guid id);

        Task<ICollection<Order>> GetAll(Guid id);
    }
}
