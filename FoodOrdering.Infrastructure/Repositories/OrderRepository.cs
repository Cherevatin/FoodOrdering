using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using FoodOrdering.Domain.Aggregates.OrderAggregate;

namespace FoodOrdering.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(FoodOrderingContext context) : base(context)
        {
        }

        public async Task<Order> GetOrder(Guid id)
        {
            return await _entities.Include(p => p.OrderItems).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<Order>> GetAll(Guid id)
        {
            return await _entities.Include(p => p.OrderItems).ToListAsync();
        }
    }
}
