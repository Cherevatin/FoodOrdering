using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrdering.Application.Interfaces;
using FoodOrdering.Presentation.ViewModels.Menu;
using System.Collections.Generic;
using FoodOrdering.Application.Dtos.Menu;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodOrdering.Presentation.Controllers
{
    [Route("api/menu")]
    [ApiController]
    public class MenuController : Controller
    {
        private readonly IMenuService _service;

        private readonly IMapper _mapper;
        public MenuController(IMenuService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("all-dishes-details")]
        public async Task<IActionResult> GetAllMenus()
        {
            try
            {
                var dto = await _service.GetAllMenusAsync();
                var viewModel = _mapper.Map<List<GotAllMenusViewModel>>(dto);
                return Ok(viewModel);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("all-info/{id}")]
        public async Task<IActionResult> MenuAllInfo(Guid menuId)
        {
            try
            {
                var dto = await _service.GetMenuAllInfo(menuId);
                var viewModel = _mapper.Map<GotMenuViewModel>(dto);

                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> MenuDetails(Guid menuId)
        {
            try
            {
                var dto = await _service.GetMenuDetails(menuId);
                var viewModel = _mapper.Map<GotMenuDetailsViewModel>(dto);

                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("dishes/{id}")]
        public async Task<IActionResult> MenuDishes(Guid menuId)
        {
            try
            {
                var dto = await _service.GetAllDishes(menuId);
                var viewModel = _mapper.Map<GotDishesViewModel>(dto);

                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddMenu(AddMenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                AddMenuDto dto = _mapper.Map<AddMenuDto>(model);

                await _service.CreateMenuAsync(dto);

                return Ok("Menu has been created");
            }
            else
            {
                return BadRequest("Model not valid");
            }
            
        }

        [HttpPut("add-dish/{id}")]
        public async Task<IActionResult> AddDish(Guid menuId, AddDishToMenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                AddDishToMenuDto dto = _mapper.Map<AddDishToMenuDto>(model);

                try
                {
                    await _service.AddDishToMenu(menuId, dto);

                    return Ok("Dish has been added");
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

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditMenu(Guid menuId, EditMenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                EditMenuDto dto = _mapper.Map<EditMenuDto>(model);
                try
                {
                    await _service.UpdateMenuAsync(menuId, dto);
                    return Ok("Menu has been updated");
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
        public async Task<IActionResult> DeleteMenu(Guid menuId)
        {
            try
            {
                await _service.DeleteMenuAsync(menuId);
                return Ok("Menu has been deleted");
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
