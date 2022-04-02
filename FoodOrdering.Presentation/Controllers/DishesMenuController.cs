using System;
using Microsoft.AspNetCore.Mvc;

using FoodOrdering.Domain.Entities;
using FoodOrdering.Application.DishesMenuService;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodOrdering.Presentation.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DishesMenuController : ControllerBase
    {
        private readonly IDishesMenuService _service;

        public DishesMenuController(IDishesMenuService service)
        {
            _service = service;
        }

        [HttpGet(nameof(GetAllDishesMenus))]
        public async Task<IActionResult> GetAllDishesMenus()
        {
            var result = await _service.GetAllDishesMenusAsync();
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No menus found");
        }

        [HttpGet(nameof(GetDishesMenu) + "/{id}")]
        public async Task<IActionResult> GetDishesMenu(Guid id)
        {
            var result = await _service.GetDishesMenuAsync(id);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("Menu not found");

        }

        [HttpPost(nameof(CreateDishesMenu))]
        public async Task<IActionResult> CreateDishesMenu(DishesMenu dishesMenu)
        {
            await _service.CreateDishesMenuAsync(dishesMenu);
            return Ok("Menu has been created");
        }

        [HttpPut(nameof(UpdateDishesMenu) + "/{id}")]
        public async Task<IActionResult> UpdateDishesMenu(DishesMenu dishesMenu)
        {
            await _service.UpdateDishesMenuAsync(dishesMenu);
            return Ok("Menu has been updated");
        }


        [HttpDelete(nameof(DeleteDishesMenu) + "/{id}")]
        public async Task<IActionResult> DeleteDishesMenu(Guid id)
        {
            await _service.DeleteDishesMenuAsync(id);
            return Ok("Menu has been deleted");
        }
    }
}
