using AutoMapper;

using FoodOrdering.Application.Dtos.Order;
using FoodOrdering.Presentation.ViewModels;

namespace FoodOrdering.Presentation.AutoMapper
{
    public class OrderAutoMapperPresentation : Profile
    {
        public OrderAutoMapperPresentation()
        {
            CreateMap<PlaceOrderViewModel, PlaceOrderDto>();
        }
    }
}
