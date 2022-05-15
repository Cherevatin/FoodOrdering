using System;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using FoodOrdering.Domain.Common;
using FoodOrdering.Domain.Aggregates.OrderAggregate;
using FoodOrdering.Application.Dtos.Order;
using FoodOrdering.Application.Exception;

namespace FoodOrdering.Application.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Place(Guid basketId, PlaceOrderDto dto)
        {
            var basket = await _unitOfWork.Baskets.GetBasketById(basketId);

            if(basket == null)
            {
                throw new ApplicationNotFoundException("Basket not found");
            }

            if (basket.IsEmpty())
            {
                throw new ApplicationValidationException("Basket is empty"); //  ?????
            }

            var groupedBasketItems = basket.BasketItems
                .GroupBy(p => p.MenuId)
                .ToDictionary(p => p.Key, p => p.ToList()) ;

            foreach(var basketItemGroup in groupedBasketItems)
            {
                var menu = await _unitOfWork.Menus.Get(basketItemGroup.Key);
                    
                Order order = new(basket.CustomerId, dto.ExecutionDate);

                foreach(var basketItem in basketItemGroup.Value)
                {
                    var dish = await _unitOfWork.Dishes.Get(basketItem.DishId);
                    order.AddItem(dish.Id, dish.Name, dish.Price, basketItem.NumberOfServings);
                }
                    
                await _unitOfWork.Orders.AddAsync(order);
            }

            _unitOfWork.Baskets.Remove(basket);
            await _unitOfWork.Save();

        }

        public async Task Accept(Guid orderId)
        {
            var order = await _unitOfWork.Orders.GetOrder(orderId);

            if (order == null)
            {
                throw new ApplicationNotFoundException("Order not found");
            }

            order.Accept();
            _unitOfWork.Orders.Update(order);
            await _unitOfWork.Save();
        }

        public async Task Cancel(Guid orderId)
        {
            var order = await _unitOfWork.Orders.GetOrder(orderId);

            if (order == null)
            {
                throw new ApplicationNotFoundException("Order not found");
            }
            
            if (DateTime.Now > order.ExecutionDate)
            {
                throw new ApplicationValidationException("Too late, sorry");   // ????
                
            }

            order.Cancel();
            _unitOfWork.Orders.Update(order);
            await _unitOfWork.Save();
        }
    }
}
