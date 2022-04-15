using AutoMapper;
using FoodOrdering.Application.Dtos.Dish;
using FoodOrdering.Domain.Entities;

namespace FoodOrdering.Application.AutoMapper
{
    public class DishAutoMapperApplication : Profile
    {
        public DishAutoMapperApplication()
        {
            CreateMap<Dish, GotAllDishesDto>();
            CreateMap<Dish, GotDishDto>();

        }
    }
}
