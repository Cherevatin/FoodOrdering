using FoodOrdering.Domain.Aggregates.UserAggregate;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FoodOrdering.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(FoodOrderingContext context) : base(context)
        {
        }

        public async Task<User> Get(string email)
        {
            return await _entities.FirstOrDefaultAsync(p => p.Email == email);
        }
    }
}
