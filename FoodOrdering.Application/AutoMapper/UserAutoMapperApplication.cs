using AutoMapper;

using FoodOrdering.Application.Dtos.User;
using FoodOrdering.Domain.Aggregates.UserAggregate;

namespace FoodOrdering.Application.AutoMapper
{
    public class UserAutoMapperApplication : Profile
    {
        public UserAutoMapperApplication()
        {
            CreateMap<User, GetAllUsersDto>()
                .ForMember(m => m.Role, opt => opt.MapFrom(p => p.Role.ToString()));
            CreateMap<User, GetUserDto>();
        }
    }
}
