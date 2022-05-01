using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using FoodOrdering.Application.Dtos.Dish;
using FoodOrdering.Presentation.ViewModels.Dish;
using FoodOrdering.Application.Services.DishService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodOrdering.Presentation.Controllers
{
    [Route("api/dish")]
    [ApiController]
    public class DishController : Controller
    {
        private readonly IDishService _dishService;

        private readonly IMapper _mapper;

        public DishController(IDishService dishService, IMapper mapper)
        {
            _dishService = dishService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddDish(AddDishViewModel model)
        {
            if (ModelState.IsValid)
            {
                AddDishDto dto = _mapper.Map<AddDishDto>(model);

                await _dishService.Add(dto);

                return Ok("Dish has been created");
            }
            else
            {
                return BadRequest("Model not valid");
            }
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllDishes()
        {
            var dto = await _dishService.GetAll();
            var viewModel = _mapper.Map<List<GetAllDishesViewModel>>(dto);

            return Ok(viewModel);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetDish(Guid dishId)
        {
            var dto = await _dishService.Get(dishId);
            var viewModel = _mapper.Map<GetDishViewModel>(dto);
            return Ok(viewModel);
        }


        [HttpPut("edit")]
        public async Task<IActionResult> EditDish(Guid dishId, EditDishViewModel model)
        {
            if (ModelState.IsValid)
            {
                UpdateDishDto dto = _mapper.Map<UpdateDishDto>(model);
          
                await _dishService.Update(dishId, dto);
                return Ok("Dish has been updated");
            }
            else
            {
                return BadRequest("Model not valid");
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteDish(Guid dishId)
        {
            await _dishService.Delete(dishId);
            return Ok("Dish has been deleted");
        }
    }
}
