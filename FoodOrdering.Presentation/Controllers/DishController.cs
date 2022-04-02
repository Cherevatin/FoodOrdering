using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using FoodOrdering.Application.DishService;
using FoodOrdering.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodOrdering.Presentation.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DishController : ControllerBase
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
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No dishes found");
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

        [HttpPost(nameof(CreateDish))]
        public async Task<ActionResult<Dish>> CreateDish(Dish dish)
        {
            await _service.CreateDishAsync(dish);
            return Ok("Dish has been created");
        }

        [HttpPut(nameof(UpdateDish)+"/{id}")]
        public async Task<ActionResult> UpdateDish(Guid id, Dish dish)
        {
            if (id != dish.Id)
            {
                return BadRequest();
            }

            await _service.UpdateDishAsync(dish);
            return Ok("Dish has been updated");
        }

        [HttpDelete(nameof(DeleteDish) + "/{id}")]
        public async Task<ActionResult> DeleteDish(Guid id)
        {
            try
            {
                await _service.DeleteDishAsync(id);
                return Ok("Dish has been deleted");
            }
            catch
            {
                return NotFound("Dish not found");
            }
        }
    }
}
