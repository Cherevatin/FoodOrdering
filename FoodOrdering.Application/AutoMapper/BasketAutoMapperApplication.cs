using AutoMapper;

using FoodOrdering.Application.Dtos.Basket;
using FoodOrdering.Domain.Aggregates.BasketAggregate;
using FoodOrdering.Domain.Aggregates.DishAggregate;
using FoodOrdering.Domain.Aggregates.MenuAggregate;

namespace FoodOrdering.Application.AutoMapper
{
    public class BasketAutoMapperApplication : Profile
    {
        public BasketAutoMapperApplication()
        {
            CreateMap<CreateBasketDto, Basket>();

            CreateMap<Basket, GotBasketDto>();

            CreateMap<Dish, BasketDishDto>();
            CreateMap<Menu, BasketMenuDto>()
                .ForMember(p => p.MenuId, opt => opt.MapFrom(s=>s.Id));

        }
    }
}
