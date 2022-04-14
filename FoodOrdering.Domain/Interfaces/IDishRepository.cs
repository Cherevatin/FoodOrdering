using FoodOrdering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Domain.Interfaces
{
    public interface IDishRepository : IGenericRepository<Dish>
    {
        Task<bool> DishExists(Guid id);
    }
}
