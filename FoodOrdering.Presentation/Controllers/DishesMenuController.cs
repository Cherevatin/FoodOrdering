using System;
using Microsoft.AspNetCore.Mvc;

using FoodOrdering.Domain.Entities;
using FoodOrdering.Application.DishesMenuService;

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
        public IActionResult GetAllDishesMenus()
        {
            var result = _service.GetAllDishesMenus();
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No menus found");
        }

        [HttpGet(nameof(GetDishesMenu) + "/{id}")]
        public IActionResult GetDishesMenu(Guid id)
        {
            var result = _service.GetDishesMenu(id);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("Menu not found");

        }

        [HttpPost(nameof(CreateDishesMenu))]
        public IActionResult CreateDishesMenu(DishesMenu dishesMenu)
        {
            _service.CreateDishesMenu(dishesMenu);
            return Ok("Menu has been created");
        }

        [HttpPut(nameof(UpdateDishesMenu) + "/{id}")]
        public IActionResult UpdateDishesMenu(DishesMenu dishesMenu)
        {
            _service.UpdateDishesMenu(dishesMenu);
            return Ok("Menu has been updated");
        }


        [HttpDelete(nameof(DeleteDishesMenu) + "/{id}")]
        public IActionResult DeleteDishesMenu(Guid id)
        {
            _service.DeleteDishesMenu(id);
            return Ok("Menu has been deleted");
        }
    }
}
