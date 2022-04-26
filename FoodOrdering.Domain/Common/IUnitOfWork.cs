using FoodOrdering.Domain.Aggregates.BasketAggregate;
using FoodOrdering.Domain.Aggregates.DishAggregate;
using FoodOrdering.Domain.Aggregates.MenuAggregate;
using FoodOrdering.Domain.Aggregates.OrderAggregate;
using System.Threading.Tasks;

namespace FoodOrdering.Domain.Common
{
    public interface IUnitOfWork
    {
        IDishRepository Dishes { get; }

        IMenuRepository Menus { get; }

        IBasketRepository Baskets { get; }

        IOrderRepository Orders { get; }

        Task<int> Save();
    }
}
