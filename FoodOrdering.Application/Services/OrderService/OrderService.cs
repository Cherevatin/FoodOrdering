using AutoMapper;
using FoodOrdering.Application.Dtos.Order;
using FoodOrdering.Application.Dtos.Order.GotGroupByCustomer;
using FoodOrdering.Domain.Aggregates.DishAggregate;
using FoodOrdering.Domain.Aggregates.MenuAggregate;
using FoodOrdering.Domain.Aggregates.OrderAggregate;
using FoodOrdering.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (basketId == Guid.Empty)
            {
                throw new Exception("Id is empty");
            }
            else if (dto is null)
            {
                throw new Exception("DTO is empty");
            }

            var basket = await _unitOfWork.Baskets.GetBasketById(basketId);

            if(basket is null)
            {
                throw new Exception("Basket not found");
            }

            if (basket.IsNotEmpty())
            {
        
                var groupedBasketItems = basket.BasketItems
                    .GroupBy(p => p.MenuId)
                    .ToDictionary(p => p.Key, p => p.ToList()) ;

                foreach(var basketItemGroup in groupedBasketItems)
                {
                    Menu menu = await _unitOfWork.Menus.GetByIdAsync(basketItemGroup.Key);
                    
                    Order order = new(basket.CustomerId, dto.ExecutionDate);

                    foreach(var basketItem in basketItemGroup.Value)
                    {
                        Dish dish = await _unitOfWork.Dishes.GetByIdAsync(basketItem.DishId);
                        order.AddItem(dish.Id, dish.Name, dish.Price, basketItem.NumberOfServings);
                    }
                    
                    await _unitOfWork.Orders.AddAsync(order);
                }

                _unitOfWork.Baskets.Remove(basket);
                await _unitOfWork.Save();
            }
            else
            {
                throw new Exception("Basket is empty");
            }
        }

        public async Task Accept(Guid orderId)
        {
            if (orderId == Guid.Empty)
            {
                throw new Exception("Id is empty");
            }

            Order order = await _unitOfWork.Orders.Get(orderId);

            if (order is null)
            {
                throw new Exception("Order not found");
            }
            order.Accept();
            _unitOfWork.Orders.Update(order);
            await _unitOfWork.Save();
        }

        public async Task Cancel(Guid orderId)
        {
            if (orderId == Guid.Empty)
            {
                throw new Exception("Id is empty");
            }

            Order order = await _unitOfWork.Orders.Get(orderId);

            if (order is null)
            {
                throw new Exception("Order not found");
            }
            
            if (DateTime.Now < order.ExecutionDate)
            {
                order.Cancel();
                _unitOfWork.Orders.Update(order);
                await _unitOfWork.Save();
            }
            else
            {
                throw new Exception("Too late, sorry");
            }
        }

        //public async Task<GroupByCustomerDto> GroupByCustomer()
        //{
        //    var orders = await _unitOfWork.Orders.GetAllAsync();

        //    var grouppedByCustomerOrders = orders.GroupBy(p => p.CustomerId);
        //}
    }
}
