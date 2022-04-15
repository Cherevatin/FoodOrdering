using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using AutoMapper;
using FoodOrdering.Presentation.ViewModels.Dish;
using FoodOrdering.Application.Interfaces;
using FoodOrdering.Application.Dtos.Dish;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodOrdering.Presentation.Controllers
{
    [Route("api/dish")]
    [ApiController]
    public class DishController : Controller
    {
        private readonly IDishService _service;

        private readonly IMapper _mapper;

        public DishController(IDishService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllDishes()
        {
            try
            {
                var dto = await _service.GetAllDishesAsync();
                var viewModel = _mapper.Map<List<GotAllDishesViewModel>>(dto);

                return Ok(viewModel);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetDish(Guid dishId)
        {
            try
            {
                var dto = await _service.GetDishAsync(dishId);
                var viewModel = _mapper.Map<GotDishViewModel>(dto);
                return Ok(viewModel);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddDish(AddDishViewModel model)
        {
            if (ModelState.IsValid)
            {
                AddDishDto dto = _mapper.Map<AddDishDto>(model);

                await _service.CreateDishAsync(dto);

                return Ok("Dish has been created");
            }
            else
            {
                return BadRequest("Model not valid");
            }
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditDish(Guid dishId, EditDishViewModel model)
        {
            if (ModelState.IsValid)
            {
                EditDishDto dto = _mapper.Map<EditDishDto>(model);
                try 
                { 
                    await _service.UpdateDishAsync(dishId, dto);
                    return Ok("Dish has been updated");
                }
                catch(Exception ex)
                {
                    return NotFound(ex.Message);
                }
            }
            else
            {
                return BadRequest("Model not valid");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteDish(Guid dishId)
        {
            try
            {
                await _service.DeleteDishAsync(dishId);
                return Ok("Dish has been deleted");
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
