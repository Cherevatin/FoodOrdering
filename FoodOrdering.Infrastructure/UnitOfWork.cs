using System.Threading.Tasks;

using FoodOrdering.Domain.Common;
using FoodOrdering.Domain.Aggregates.DishAggregate;
using FoodOrdering.Domain.Aggregates.MenuAggregate;
using FoodOrdering.Domain.Aggregates.BasketAggregate;
using FoodOrdering.Domain.Aggregates.OrderAggregate;

namespace FoodOrdering.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FoodOrderingContext _context;

        public IDishRepository Dishes { get; }

        public IMenuRepository Menus { get; }

        public IBasketRepository Baskets { get; }

        public IOrderRepository Orders { get; }

        public UnitOfWork(FoodOrderingContext context, 
            IDishRepository dishRepository, 
            IMenuRepository menuRepository,
            IBasketRepository basketRepository,
            IOrderRepository orderRepository)
        {
            _context = context;
            Dishes = dishRepository;
            Menus = menuRepository;
            Baskets = basketRepository;
            Orders = orderRepository;
        }

        public async Task<int> Save() => await _context.SaveChangesAsync();
       
    }
}
