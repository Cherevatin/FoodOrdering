using AutoMapper;

using FoodOrdering.Application.Dtos.Basket;
using FoodOrdering.Presentation.ViewModels.Basket;

namespace FoodOrdering.Presentation.AutoMapper
{
    public class BasketAutoMapperPresentation : Profile
    {
        public BasketAutoMapperPresentation()
        {
            CreateMap<CreateBasketViewModel, CreateBasketDto>();
            CreateMap<AddDishToBasketViewModel, AddDishDto>();
            CreateMap<UpdateBasketItemViewModel, UpdateBasketItemDto>();

            CreateMap<GetBasketDto, GetBasketViewModel>();
            CreateMap<GetBasketDto.Dish, GetBasketViewModel.Dish>();
            CreateMap<GetBasketDto.Menu, GetBasketViewModel.Menu>();
        }
    }
}
