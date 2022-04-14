using AutoMapper;
using FoodOrdering.Application.Dtos.Dish;
using FoodOrdering.Application.Dtos.DishMenu;
using FoodOrdering.Domain.Entities;

namespace FoodOrdering.Application.Infrastructure
{
    public class ApplicationAutoMapper : Profile
    {
        public ApplicationAutoMapper()
        {
            CreateMap<Dish, GetAllDishesDto>();
            CreateMap<Dish, DishDto>();

            CreateMap<Menu, MenuDto>();
            CreateMap<Menu, GetAllMenusDto>();
        }
    }
}
