using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using FoodOrdering.Domain.Aggregates.MenuAggregate;

namespace FoodOrdering.Infrastructure.Repositories
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        public MenuRepository(FoodOrderingContext context) : base(context)
        {

        }

        public async Task<bool> IsExist(Guid id)
        {
            return await _entities.AnyAsync(e => e.Id == id);
        }

        public async Task<Menu> GetMenuWithDishes(Guid id)
        {
            return await _entities.Include(m => m.MenuItems).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Menu>> GetAllWithDishes()
        {
            return await _entities.Include(m => m.MenuItems).ToListAsync();
        }
    }
}
