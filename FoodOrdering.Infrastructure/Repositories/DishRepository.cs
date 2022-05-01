using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using FoodOrdering.Domain.Aggregates.DishAggregate;

namespace FoodOrdering.Infrastructure.Repositories
{
    public class DishRepository : GenericRepository<Dish>, IDishRepository
    {
        public DishRepository(FoodOrderingContext context) : base(context)
        {

        }
        public async Task<bool> IsExist(Guid id)
        {
            return await _entities.AnyAsync(e => e.Id == id);
        }
    }
}
