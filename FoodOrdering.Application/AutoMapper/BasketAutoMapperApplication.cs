using AutoMapper;

using FoodOrdering.Application.Dtos.Basket;
using FoodOrdering.Domain.Aggregates.BasketAggregate;

namespace FoodOrdering.Application.AutoMapper
{
    public class BasketAutoMapperApplication : Profile
    {
        public BasketAutoMapperApplication()
        {
            CreateMap<CreateBasketDto, Basket>();

            CreateMap<Basket, GotBasketDto>();
        }
    }
}
