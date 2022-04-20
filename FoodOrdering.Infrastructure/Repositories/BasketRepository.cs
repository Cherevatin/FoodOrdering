using FoodOrdering.Domain.Aggregates.BasketAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Infrastructure.Repositories
{
    public class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
        public BasketRepository(FoodOrderingContext context) : base(context)
        {
        }

        public async Task<bool> BasketExists(Guid customerOrBasketId)
        {
            return await _entities.AnyAsync(e => e.CustomerId == customerOrBasketId || e.Id == customerOrBasketId);
        }

        public async Task<Basket> GetBasketById(Guid id)
        {
            return await _entities.Include(p => p.BasketItems).FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
