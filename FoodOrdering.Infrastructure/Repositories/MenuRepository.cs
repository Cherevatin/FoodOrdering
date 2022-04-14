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

        Task<bool> IMenuRepository.MenuExists(Guid id) => _entities.AnyAsync(e => e.Id == id);
        
        async Task IMenuRepository.MenuUpdate(Menu newMenu)
        {
            var oldMenu = await _entities.Include(m => m.Dishes).FirstOrDefaultAsync(m => m.Id == newMenu.Id);
            
            oldMenu.Update(newMenu);
        }

        public async Task AddDishes(Guid menuId, List<Guid> dishes)
        {
            var menu = await _entities.Include(m => m.Dishes).FirstOrDefaultAsync(m => m.Id == menuId);

            menu.AddDish(dishes);
        }
    }   
}
