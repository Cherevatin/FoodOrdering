using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FoodOrdering.Application.Dtos.User;

namespace FoodOrdering.Application.Services.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<GetAllUsersDto>> GetAll();
        
        Task<GetUserDto> Get(Guid id);
        
        Task Delete(Guid userId);

        Task AppointAsManager(Guid userId);

        Task AppointAsCook(Guid userId);

        Task AppointAsEmployee(Guid userId);
        
        Task Register(RegisterDto dto);

        Task<string> Login(LoginDto dto);
    }
}
