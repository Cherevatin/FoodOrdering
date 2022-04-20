using AutoMapper;

using FoodOrdering.Application.Dtos.Dish;
using FoodOrdering.Presentation.ViewModels.Dish;

namespace FoodOrdering.Presentation.AutoMapper
{
    public class DishAutoMapperPresentation : Profile
    {
        public DishAutoMapperPresentation()
        {
            CreateMap<AddDishViewModel, AddDishDto>();
            CreateMap<EditDishViewModel, EditDishDto>();
            CreateMap<GotDishDto, GotDishViewModel>();
            CreateMap<GotAllDishesDto, GotAllDishesViewModel>();
        }
    }
}
