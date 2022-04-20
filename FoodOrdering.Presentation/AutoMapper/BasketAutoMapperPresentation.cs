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

            CreateMap<GotBasketDto, GotBasketViewModel>();
        }
    }
}
