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
            CreateMap<EditMenuViewModel, EditMenuDto>();
            CreateMap<GotMenuDto, GotMenuViewModel>();
            CreateMap<GotAllMenusDto, GotAllMenusViewModel>();
            CreateMap<GotMenuDetailsDto, GotMenuDetailsViewModel>();
            CreateMap<GotDishesDto, GotDishesViewModel>();
        }
    }
}
