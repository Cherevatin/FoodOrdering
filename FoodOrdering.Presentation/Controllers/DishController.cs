using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using FoodOrdering.Application.DishService;
using FoodOrdering.Domain.Entities;
using FoodOrdering.Presentation.ViewModels;
using AutoMapper;
using FoodOrdering.Application.Infrastructure;
using FoodOrdering.Application.DTO.Dish;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodOrdering.Presentation.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DishController : Controller
    {
        private readonly IDishService _service;

        public DishController(IDishService service)
        {
            _service = service;
        }

        [HttpGet(nameof(GetAllDishes))]
        public async Task<IActionResult> GetAllDishes()
        {
            var result = await _service.GetAllDishesAsync();
            return Ok(result);
        }

        [HttpGet(nameof(GetDish) + "/{id}")]
        public async Task<IActionResult> GetDish(Guid id)
        {
            var result = await _service.GetDishAsync(id);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("Dish not found");
        }

        [HttpPost(nameof(AddDish))]
        public async Task<IActionResult> AddDish(AddDishViewModel model)
        {
            DishDTO dishDto = new()
            {
                Name = model.Name,
                Ingredients = model.Ingredients,
                Price = model.Price,
                Proteins = model.Proteins,
                Fats = model.Fats,
                Carbohydrates = model.Carbohydrates,
                Calories = model.Calories,
                Weight = model.Weight
            };

            await _service.CreateDishAsync(dishDto);
            return Ok("Dish has been created");
        }

        [HttpPut(nameof(EditDish)+"/{id}")]
        public async Task<IActionResult> EditDish(Guid id, EditDishViewModel model)
        {
            if (ModelState.IsValid)
            {
                try { 
                    DishDTO dishDto = new()
                    {
                        Id = id,
                        Name = model.Name,
                        Ingredients = model.Ingredients,
                        Price = model.Price,
                        Proteins = model.Proteins,
                        Fats = model.Fats,
                        Carbohydrates = model.Carbohydrates,
                        Calories = model.Calories,
                        Weight = model.Weight
                    };

                    await _service.UpdateDishAsync(dishDto);
                    return Ok("Dish has been updated");
                }
                catch(ValidationException ex)
                {
                    return NotFound(ex.Message);
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpDelete(nameof(DeleteDish) + "/{id}")]
        public async Task<IActionResult> DeleteDish(Guid id)
        {
            if (await _service.DishExists(id))
            {
                await _service.DeleteDishAsync(id);
                return Ok("Dish has been deleted");
            }
            else
            {
                return NotFound("Dish not found");
            }
        }
    }
}
