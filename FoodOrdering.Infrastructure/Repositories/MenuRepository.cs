using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using FoodOrdering.Domain.Entities;
using FoodOrdering.Domain.Interfaces;
using System.Collections.Generic;

namespace FoodOrdering.Infrastructure.Repositories
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        public MenuRepository(FoodOrderingContext context)
            : base(context)
        {

        }

        public async Task<bool> MenuExists(Guid id)
        {
            return await _entities.AnyAsync(e => e.Id == id);
        }

        public async Task<Menu> GetMenuWithDishesById(Guid id)
        {
            return await _entities.Include(m => m.Dishes).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
