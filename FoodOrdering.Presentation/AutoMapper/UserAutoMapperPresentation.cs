using AutoMapper;
using FoodOrdering.Application.Dtos.User;
using FoodOrdering.Presentation.ViewModels.User;

namespace FoodOrdering.Presentation.AutoMapper
{
    public class UserAutoMapperPresentation : Profile
    {
        public UserAutoMapperPresentation()
        {
            CreateMap<RegisterViewModel, RegisterDto>();
            CreateMap<LoginViewModel, LoginDto>();

            CreateMap<GetAllUsersDto, GetAllUsersViewModel>();
            CreateMap<GetUserDto, GetUserViewModel>();
        }
    }
}
