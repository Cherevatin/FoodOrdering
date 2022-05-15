using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using AutoMapper;

using FoodOrdering.Application.Services.BasketService;
using FoodOrdering.Presentation.ViewModels.Basket;
using FoodOrdering.Application.Dtos.Basket;

namespace FoodOrdering.Presentation.Controllers
{
    [Route("api/basket")]
    [ApiController]
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBasket(CreateBasketViewModel model)
        {
            if (ModelState.IsValid)
            {
                var basketDto = _mapper.Map<CreateBasketDto>(model);

                await _basketService.Create(basketDto);

                return Ok("Basket has been added");
            }
            else
            {
                return BadRequest("Model not valid");
            }

        }

        [HttpGet("get")]
        public async Task<IActionResult> GetBasket(Guid basketId)
        {
            var basketDto = await _basketService.Get(basketId);
            var basketViewModel = _mapper.Map<GetBasketViewModel>(basketDto);
            return Ok(basketViewModel);
        }

        [HttpPut("update-number-of-servings")]
        public async Task<IActionResult> UpdateNumberOfServings(Guid basketId, UpdateBasketItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<UpdateBasketItemDto>(model);

                await _basketService.UpdateNumberOfServings(basketId, dto);

                return Ok("Number of servings has been updated");
            }
            else
            {
                return BadRequest("Model not valid");
            }
        }

        [HttpPut("add-dish")]
        public async Task<IActionResult> AddDishToBasket(AddDishToBasketViewModel model)
        {
            if (ModelState.IsValid)
            {
                var addDishDto = _mapper.Map<AddDishDto>(model);

                await _basketService.AddDish(addDishDto);

                return Ok("Dish has been added to basket");
            }
            else
            {
                return BadRequest("Model not valid");
            }
        }

        [HttpPut("delete-dish")]
        public async Task<IActionResult> DeleteDishFromBasketBasket(Guid basketId, Guid dishId)
        {
                await _basketService.DeleteDish(basketId, dishId);
                return Ok("Dish has been deleted from basket");
        }

        [HttpPut("clear")]
        public async Task<IActionResult> ClearBasket(Guid basketId)
        {
            await _basketService.Clear(basketId);
            return Ok("Basket has been cleared");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteBasket(Guid basketId)
        {
            await _basketService.Delete(basketId);
            return Ok("Basket has been deleted");
        }
    }
}
