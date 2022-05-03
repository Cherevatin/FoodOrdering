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

            CreateMap<Basket, GetBasketDto>()
                .ForMember(p => p.Menus, opt => opt.MapFrom(
                    (src, dst, _, context) => context.Options.Items["Menus"]));

            CreateMap<Dish, GetBasketDto.Dish>()
                .ForMember(p => p.DishId, opt => opt.MapFrom(s => s.Id))
                .ForMember(p => p.DishTitle, opt => opt.MapFrom(s => s.Name));

            CreateMap<Menu, GetBasketDto.Menu>()
                .ForMember(p => p.MenuId, opt => opt.MapFrom(s => s.Id))
                .ForMember(p => p.Dishes, opt => opt.MapFrom(
                    (src, dst, _, context) => context.Options.Items["Dishes"]));

        }
    }
}
