using System.Threading.Tasks;

using FoodOrdering.Domain.Common;
using FoodOrdering.Domain.Aggregates.DishAggregate;
using FoodOrdering.Domain.Aggregates.MenuAggregate;
using FoodOrdering.Domain.Aggregates.BasketAggregate;
using FoodOrdering.Domain.Aggregates.OrderAggregate;
using FoodOrdering.Domain.Aggregates.UserAggregate;

namespace FoodOrdering.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FoodOrderingContext _context;

        public IUserRepository Users { get; }

        public IDishRepository Dishes { get; }

        public IMenuRepository Menus { get; }

        public IBasketRepository Baskets { get; }

        public IOrderRepository Orders { get; }

        public UnitOfWork(FoodOrderingContext context, 
            IDishRepository dishRepository, 
            IMenuRepository menuRepository,
            IBasketRepository basketRepository,
            IOrderRepository orderRepository, 
            IUserRepository userRepository)
        {
            _context = context;
            Dishes = dishRepository;
            Menus = menuRepository;
            Baskets = basketRepository;
            Orders = orderRepository;
            Users = userRepository;
        }

        public async Task Save() => await _context.SaveChangesAsync();
    }
}
