using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using FoodOrdering.Domain.Entities;
using FoodOrdering.Domain.Interfaces;

namespace FoodOrdering.Infrastructure.Repositories
{
    public class DishRepository : GenericRepository<Dish>, IDishRepository
    {
        public DishRepository(FoodOrderingContext context)
            : base(context)
        {

        }
        public async Task<bool> DishExists(Guid id)
        {
            return await _entities.AnyAsync(e => e.Id == id);
        }
        
    }
}
