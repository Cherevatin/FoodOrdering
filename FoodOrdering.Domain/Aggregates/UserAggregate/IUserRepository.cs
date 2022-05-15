using FoodOrdering.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Domain.Aggregates.UserAggregate
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> Get(string email);
    }
}
