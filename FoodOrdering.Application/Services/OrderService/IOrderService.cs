using FoodOrdering.Application.Dtos.Order;
using System;
using System.Threading.Tasks;

namespace FoodOrdering.Application.Services.OrderService
{
    public interface IOrderService
    {
        Task Place(Guid basketId, PlaceOrderDto dto);

        Task Accept(Guid orderId);

        Task Cancel(Guid orderId);

        //Task GroupByCustomer();

        //Task GroupByDish();

        //Task GroupByTime();
    }
}
