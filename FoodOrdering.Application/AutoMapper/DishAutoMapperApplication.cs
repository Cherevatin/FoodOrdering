using AutoMapper;
using FoodOrdering.Application.Dtos.Dish;
using FoodOrdering.Domain.Aggregates.DishAggregate;

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
