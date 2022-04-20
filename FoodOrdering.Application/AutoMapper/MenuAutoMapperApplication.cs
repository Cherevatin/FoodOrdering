using AutoMapper;
using FoodOrdering.Application.Dtos.Menu;
using FoodOrdering.Domain.Aggregates.MenuAggregate;

namespace FoodOrdering.Application.AutoMapper
{
    public class MenuAutoMapperApplication : Profile
    {
        public MenuAutoMapperApplication()
        {
            CreateMap<Menu, GotAllMenusDto>();
            CreateMap<Menu, GotMenuDto>();
            CreateMap<Menu, GotMenuDetailsDto>();
            CreateMap<Menu, GotDishesDto>();
        }
    }
}
