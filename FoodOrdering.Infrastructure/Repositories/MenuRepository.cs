using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using FoodOrdering.Domain.Aggregates.MenuAggregate;

namespace FoodOrdering.Infrastructure.Repositories
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        public MenuRepository(FoodOrderingContext context) : base(context)
        {

        }

        public async Task<bool> MenuExists(Guid id)
        {
            return await _entities.AnyAsync(e => e.Id == id);
        }

        public async Task<Menu> GetMenuWithDishesById(Guid id)
        {
            return await _entities.Include(m => m.MenuItems).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
