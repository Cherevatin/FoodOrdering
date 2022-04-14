using System.Threading.Tasks;

namespace FoodOrdering.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IDishRepository Dishes { get; }

        IMenuRepository Menus { get; }

        Task<int> Complete();
    }
}
