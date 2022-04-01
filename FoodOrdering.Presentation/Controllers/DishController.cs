using System;
using Microsoft.AspNetCore.Mvc;

using FoodOrdering.Domain.Entities;
using FoodOrdering.Application.DishService;

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

        //[HttpGet(nameof(GetAllDishes))]
        //public IActionResult GetAllDishes()
        //{
        //    var result = _service.GetAllDishes();
        //    if (result is not null)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest("No dishes found");
        //}

        //[HttpGet(nameof(GetDish) + "/{id}")]
        //public IActionResult GetDish(Guid id)
        //{
        //    var result = _service.GetDish(id);
        //    if (result is not null)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest("Dish not found");

        //}

        [HttpPost(nameof(CreateDish))]
        public IActionResult CreateDish(Dish dish)
        {
            _service.CreateDish(dish);
            return Ok("Dish has been created");
        }

        [HttpPut(nameof(UpdateDish)+"/{id}")]
        public IActionResult UpdateDish(Dish dish)
        {
            _service.UpdateDish(dish);
            return Ok("Dish has been updated");
        }


        [HttpDelete(nameof(DeleteDish) + "/{id}")]
        public IActionResult DeleteDish(Guid id)
        {
            _service.DeleteDish(id);
            return Ok("Dish has been deleted");
        }
    }
}
