using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.Application.Services.BasketService;
using AutoMapper;
using FoodOrdering.Presentation.ViewModels.Basket;
using FoodOrdering.Application.Dtos.Basket;

namespace FoodOrdering.Presentation.Controllers
{
    [Route("api/basket")]
    [ApiController]
    public class BasketController : Controller
    {
        private readonly IBasketService _service;

        private readonly IMapper _mapper;

        public BasketController(IBasketService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetBasket(Guid basketId)
        {
            try
            {
                GotBasketDto dto = await _service.GetBasket(basketId);
                GotBasketViewModel viewModel = _mapper.Map<GotBasketViewModel>(dto);
                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBasket(CreateBasketViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CreateBasketDto dto = _mapper.Map<CreateBasketDto>(model);

                    await _service.CreateBasketAsync(dto);

                    return Ok("Basket has been added");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Model not valid");
            }

        }

        [HttpPut("update-number-of-servings")]
        public async Task<IActionResult> UpdateNumberOfServings(Guid basketId, UpdateBasketItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                UpdateBasketItemDto dto = _mapper.Map<UpdateBasketItemDto>(model);

                await _service.UpdateNumberOfServings(basketId, dto);

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
                AddDishDto dto = _mapper.Map<AddDishDto>(model);

                await _service.AddDishAsync(dto);

                return Ok("Dish has been added to basket");
            }
            else
            {
                return BadRequest("Model not valid");
            }
        }

        [HttpDelete("delete-dish")]
        public async Task<IActionResult> DeleteDishFromBasketBasket(Guid basketId, Guid dishId)
        {
            try
            {
                await _service.DeleteDishAsync(basketId, dishId);
                return Ok("Dish has been deleted from basket");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteBasket(Guid basketId)
        {
            try
            {
                await _service.DeleteBasket(basketId);
                return Ok("Basket has been deleted");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
