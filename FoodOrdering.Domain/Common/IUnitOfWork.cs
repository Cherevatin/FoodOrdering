using System.Threading.Tasks;

using FoodOrdering.Domain.Aggregates.BasketAggregate;
using FoodOrdering.Domain.Aggregates.DishAggregate;
using FoodOrdering.Domain.Aggregates.MenuAggregate;
using FoodOrdering.Domain.Aggregates.OrderAggregate;
using FoodOrdering.Domain.Aggregates.UserAggregate;

namespace FoodOrdering.Domain.Common
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get;  }

        IDishRepository Dishes { get; }

        IMenuRepository Menus { get; }

        IBasketRepository Baskets { get; }

        IOrderRepository Orders { get; }

        Task Save();
    }
}
