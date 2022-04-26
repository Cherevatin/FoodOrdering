using AutoMapper;
using FoodOrdering.Application.Dtos.Basket;
using FoodOrdering.Domain.Aggregates.BasketAggregate;
using FoodOrdering.Domain.Aggregates.DishAggregate;
using FoodOrdering.Domain.Aggregates.MenuAggregate;
using FoodOrdering.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Application.Services.BasketService
{
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public BasketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GotBasketDto> Get(Guid basketId)
        {
            if (basketId == Guid.Empty)
            {
                throw new Exception("Basket ID not set");
            }
            else if (!await _unitOfWork.Baskets.BasketExists(basketId))
            {
                throw new Exception("Basket not found");
            }

            Basket basket = await _unitOfWork.Baskets.GetBasketById(basketId);

            GotBasketDto dto = new();
            dto.CustomerId = basket.CustomerId;

            var grouppedByMenuDictionary = basket.BasketItems
                .GroupBy(p => p.MenuId)
                .ToDictionary(p => p.Key, p => p.ToList());

            
            foreach(var group in grouppedByMenuDictionary)
            {
                
                Menu menu = await _unitOfWork.Menus.GetByIdAsync(group.Key);
                BasketMenuDto basketMenu = new()
                {
                    StartDate = menu.StartDate,
                    ExpirationDate = menu.ExpirationDate
                };
                foreach (var basketItem in group.Value)
                {
                    Dish dish = await _unitOfWork.Dishes.GetByIdAsync(basketItem.DishId);
                    BasketDishDto basketDishDto = new()
                    {
                        DishId = dish.Id,
                        DishTitle = dish.Name
                    };
                    basketMenu.Dishes.Add(basketDishDto);
                }
                dto.Items.Add(group.Key, basketMenu);
            }
            return dto;
        }

        public async Task AddDish(AddDishDto dto)
        {
            if (dto is null)
            {
                throw new Exception("Model is empty!");
            }

            bool exists = await _unitOfWork.Baskets.BasketExists(dto.BasketId);

            Basket basket;
            if (!exists)
            {
                basket = new();
                await _unitOfWork.Baskets.AddAsync(basket);
                await _unitOfWork.Save();
            }
            else
            {
                basket = await _unitOfWork.Baskets.GetBasketById(dto.BasketId);
            }

            basket.AddItem(dto.DishId, dto.MenuId);

            _unitOfWork.Baskets.Update(basket);
            await _unitOfWork.Save();
        }

        public async Task UpdateNumberOfServings(Guid basketId, UpdateBasketItemDto dto)
        {
            if (basketId == Guid.Empty)
            {
                throw new Exception("Id is empty");
            }
            else if (dto is null)
            {
                throw new Exception("Model is empty!");
            }
            Basket basket = await _unitOfWork.Baskets.GetBasketById(basketId);

            BasketItem item = basket.GetItem(dto.itemId);

            item.UpdateNumberOfServings(dto.NumberOfServings);

            basket.UpdateItem(item);

            _unitOfWork.Baskets.Update(basket);
            await _unitOfWork.Save();
        }

        public async Task Create(CreateBasketDto dto)
        {
            if (dto is null)
            {
                throw new Exception("Model is empty!");
            }
            bool exists = await _unitOfWork.Baskets.BasketExists(dto.CustomerId);
            if (exists)
            {
                throw new Exception("Basket for this employee already exists");
            }

            Basket basket = new(dto.CustomerId);
            await _unitOfWork.Baskets.AddAsync(basket);
            await _unitOfWork.Save();
        }

        public async Task DeleteDish(Guid basketId, Guid dishId)
        {
            if (dishId == Guid.Empty || basketId == Guid.Empty) 
            {
                throw new Exception("Id is empty");
            }

            Basket basket = await _unitOfWork.Baskets.GetBasketById(basketId);
            try
            {
                basket.DeleteItem(dishId);
                _unitOfWork.Baskets.Update(basket);
                await _unitOfWork.Save();
            }
            catch
            {
                throw new Exception("Item doesn't exist");
            }
            
        }

        public async Task Clear(Guid basketId)
        {
            if (basketId == Guid.Empty)
            {
                throw new Exception("Id is empty");
            }

            bool basketExists = await _unitOfWork.Baskets.BasketExists(basketId);

            if (basketExists)
            {
                Basket basket = await _unitOfWork.Baskets.GetBasketById(basketId);
                basket.ClearItems();
                _unitOfWork.Baskets.Update(basket);
                await _unitOfWork.Save();
            }
            else
            {
                throw new Exception("Basket doesn't exist");
            }

        }

        public async Task Delete(Guid basketId)
        {
            if (basketId == Guid.Empty)
            {
                throw new Exception("Id is empty");
            }

            bool basketExists = await _unitOfWork.Baskets.BasketExists(basketId);

            if (basketExists)
            {
                Basket basket = await _unitOfWork.Baskets.GetBasketById(basketId);

                _unitOfWork.Baskets.Remove(basket);
                await _unitOfWork.Save();
            }
            else
            {
                throw new Exception("Basket doesn't exist");
            }
        }
    }
}
