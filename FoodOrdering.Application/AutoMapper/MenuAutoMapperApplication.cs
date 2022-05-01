using AutoMapper;
using FoodOrdering.Application.Dtos.Menu;
using FoodOrdering.Domain.Aggregates.DishAggregate;
using FoodOrdering.Domain.Aggregates.MenuAggregate;

namespace FoodOrdering.Application.AutoMapper
{
    public class MenuAutoMapperApplication : Profile
    {
        public MenuAutoMapperApplication()
        {
            CreateMap<Menu, GetAllMenusDto>();
            CreateMap<Dish, GetAllMenusDto.Dish>();

            CreateMap<Menu, GetMenuDto>();
            CreateMap<Dish, GetMenuDto.Dish>();
        }
    }
}
