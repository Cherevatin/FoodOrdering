using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using AutoMapper;
using FoodOrdering.Application.Infrastructure;
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
                var dishesDto = await _service.GetAllDishesAsync();
                var dishesViewModel = _mapper.Map<List<GetAllDishesViewModel>>(dishesDto);

                return Ok(dishesViewModel);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetDish(Guid id)
        {
            try
            {
                var dishDto = await _service.GetDishAsync(id);
                var dishViewModel = _mapper.Map<GetDishViewModel>(dishDto);
                return Ok(dishViewModel);
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
                DishDto dishDTO = _mapper.Map<DishDto>(model);

                await _service.CreateDishAsync(dishDTO);

                return Ok("Dish has been created");
            }
            else
            {
                return BadRequest("Model not valid");
            }
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditDish(Guid id, EditDishViewModel model)
        {
            if (ModelState.IsValid)
            {
                DishDto dishDTO = _mapper.Map<DishDto>(model);

                try 
                { 
                    await _service.UpdateDishAsync(dishDTO);
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
        public async Task<IActionResult> DeleteDish(Guid id)
        {
            try
            {
                await _service.DeleteDishAsync(id);
                return Ok("Dish has been deleted");
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
