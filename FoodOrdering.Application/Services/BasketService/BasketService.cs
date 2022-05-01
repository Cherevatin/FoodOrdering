using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using FoodOrdering.Domain.Common;
using FoodOrdering.Domain.Aggregates.BasketAggregate;
using FoodOrdering.Application.Dtos.Basket;
using FoodOrdering.Application.Exception;

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

        public async Task<GetBasketDto> Get(Guid basketId)
        {
            Basket basket = await _unitOfWork.Baskets.GetBasketById(basketId);

            if (basket == null)
            {
                throw new ApplicationNotFoundException("Basket not found");
            }

            GetBasketDto basketDto = new()
            {
                CustomerId = basket.CustomerId,
                Menus = new()
            };

            var grouppedByMenuDictionary = basket.BasketItems
                .GroupBy(p => p.MenuId)
                .ToDictionary(p => p.Key, p => p.ToList());

            foreach(var group in grouppedByMenuDictionary)
            {
                var menu = await _unitOfWork.Menus.Get(group.Key);
                var basketMenu = _mapper.Map<GetBasketDto.Menu>(menu, opts =>
                {

                    opts.Items["Dishes"] = _mapper.Map<List<GetBasketDto.Dish>>(group.Value
                            .Select(async p => await _unitOfWork.Dishes.Get(p.DishId))
                            .Select(r => r.Result));

                });
                basketDto.Menus.Add(basketMenu);
            }
            return basketDto;
        }

        public async Task AddDish(AddDishDto dto)
        {
            var basket = await _unitOfWork.Baskets.GetBasketById(dto.BasketId);

            if (basket == null)
            {
                basket = new();
                await _unitOfWork.Baskets.AddAsync(basket);
                await _unitOfWork.Save();
            }

            basket.AddItem(dto.DishId, dto.MenuId);

            _unitOfWork.Baskets.Update(basket);
            await _unitOfWork.Save();
        }

        public async Task UpdateNumberOfServings(Guid basketId, UpdateBasketItemDto dto)
        {

            var basket = await _unitOfWork.Baskets.GetBasketById(basketId);

            if (basket == null)
            {
                throw new ApplicationNotFoundException("Basket not found");
            }

            basket.UpdateItem(dto.ItemId, dto.NumberOfServings);

            _unitOfWork.Baskets.Update(basket);
            await _unitOfWork.Save();
        }

        public async Task Create(CreateBasketDto dto)
        {
            bool exists = await _unitOfWork.Baskets.BasketExists(dto.CustomerId);

            if (exists)
            {
                throw new ApplicationAlreadyExistsException("Basket for this customer already exists");
            }

            Basket basket = new(dto.CustomerId);
            await _unitOfWork.Baskets.AddAsync(basket);
            await _unitOfWork.Save();
        }

        public async Task DeleteDish(Guid basketId, Guid dishId)
        {
            var basket = await _unitOfWork.Baskets.GetBasketById(basketId);

            if (basket == null)
            {
                throw new ApplicationNotFoundException("Basket not found");
            }

            basket.DeleteItem(dishId);
            _unitOfWork.Baskets.Update(basket);
            await _unitOfWork.Save();
        }

        public async Task Clear(Guid basketId)
        {
            var basket = await _unitOfWork.Baskets.GetBasketById(basketId);

            if (basket == null)
            {
                throw new ApplicationNotFoundException("Basket not found");
            }

            basket.ClearItems();
            _unitOfWork.Baskets.Update(basket);
            await _unitOfWork.Save();
        }

        public async Task Delete(Guid basketId)
        {
            var basket = await _unitOfWork.Baskets.GetBasketById(basketId);

            if (basket == null)
            {
                throw new ApplicationNotFoundException("Basket not found");
            }

            _unitOfWork.Baskets.Remove(basket);
            await _unitOfWork.Save();
        }
    }
}
