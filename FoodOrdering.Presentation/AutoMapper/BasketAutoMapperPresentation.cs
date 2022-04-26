using AutoMapper;

using FoodOrdering.Application.Dtos.Basket;
using FoodOrdering.Presentation.ViewModels.Basket;
using FoodOrdering.Presentation.ViewModels.Basket.GotBasketViewModels;

namespace FoodOrdering.Presentation.AutoMapper
{
    public class BasketAutoMapperPresentation : Profile
    {
        public BasketAutoMapperPresentation()
        {
            CreateMap<CreateBasketViewModel, CreateBasketDto>();
            CreateMap<AddDishToBasketViewModel, AddDishDto>();
            CreateMap<UpdateBasketItemViewModel, UpdateBasketItemDto>();

            CreateMap<GotBasketDto, GotBasketViewModel>();
            CreateMap<BasketDishDto, BasketDishViewModel>();
            CreateMap<BasketMenuDto, BasketMenuViewModel>();
        }
    }
}
