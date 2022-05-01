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

            CreateMap<EditDishViewModel, UpdateDishDto>();

            CreateMap<GetDishDto, GetDishViewModel>();

            CreateMap<GetAllDishesDto, GetAllDishesViewModel>();
        }
    }
}
