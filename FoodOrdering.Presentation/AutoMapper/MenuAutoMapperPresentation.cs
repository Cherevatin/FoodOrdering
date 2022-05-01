using AutoMapper;

using FoodOrdering.Application.Dtos.Menu;
using FoodOrdering.Presentation.ViewModels.Menu;

namespace FoodOrdering.Presentation
{
    public class MenuAutoMapperPresentation : Profile
    {
        public MenuAutoMapperPresentation()
        {
            CreateMap<AddMenuViewModel, AddMenuDto>();

            CreateMap<AddDishToMenuViewModel, AddDishToMenuDto>();

            CreateMap<EditMenuViewModel, UpdateMenuDto>();

            CreateMap<GetAllMenusDto, GetAllMenusViewModel>();
            CreateMap<GetAllMenusDto.Dish, GetAllMenusViewModel.Dish>();

            CreateMap<GetMenuDto, GetMenuViewModel>();
            CreateMap<GetMenuDto.Dish, GetMenuViewModel.Dish>();
        }
    }
}
