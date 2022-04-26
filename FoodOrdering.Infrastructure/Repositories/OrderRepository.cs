using FoodOrdering.Domain.Aggregates.OrderAggregate;
using FoodOrdering.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(FoodOrderingContext context) : base(context)
        {
        }

        public async Task<Order> Get(Guid id)
        {
            return await _entities.Include(p => p.OrderItems).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<Order>> GetAll(Guid id)
        {
            return await _entities.Include(p => p.OrderItems).ToListAsync();
        }
    }
}
