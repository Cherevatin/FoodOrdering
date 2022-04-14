using FoodOrdering.Domain.Entities;
using FoodOrdering.Domain.Interfaces;
using FoodOrdering.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FoodOrderingContext _context;

        public IDishRepository Dishes { get; }

        public IMenuRepository Menus { get; }

        public UnitOfWork(FoodOrderingContext context, 
            IDishRepository dishRepository, 
            IMenuRepository menuRepository)
        {
            _context = context;
            Dishes = dishRepository;
            Menus = menuRepository;
        }

        public async Task<int> Complete() => await _context.SaveChangesAsync();
       
    }
}
