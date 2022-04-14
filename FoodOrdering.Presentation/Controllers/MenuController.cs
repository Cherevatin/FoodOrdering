using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrdering.Application.Interfaces;
using FoodOrdering.Application.Dtos.DishMenu;
using FoodOrdering.Presentation.ViewModels.Menu;
using System.Collections.Generic;
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

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllMenus()
        {
            try
            {
                var menusDto = await _service.GetAllMenusAsync();
                var menuListViewModel = _mapper.Map<List<GetAllMenusViewModel>>(menusDto);
                return Ok(menuListViewModel);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetMenu(Guid id)
        {
            try
            {
                var menuDto = await _service.GetMenuAsync(id);
                var menuViewModel = _mapper.Map<GetMenuViewModel>(menuDto);

                return Ok(menuViewModel);
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
                MenuDto dishMenuDTO = _mapper.Map<MenuDto>(model);

                await _service.CreateMenuAsync(dishMenuDTO);

                return Ok("Menu has been created");
            }
            else
            {
                return BadRequest("Model not valid");
            }
            
        }

        [HttpPut("add-dish/{id}")]
        public async Task<IActionResult> AddDish(Guid id, AddDishToMenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                AddDishToMenuDto dto = _mapper.Map<AddDishToMenuDto>(model);
                dto.MenuId = id;

                try
                {
                    await _service.AddDishToMenu(dto);

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
        public async Task<IActionResult> EditMenu(Guid id, EditMenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                MenuDto menuDTO = _mapper.Map<MenuDto>(model);
                menuDTO.Id = id;

                try
                {
                    await _service.UpdateMenuAsync(menuDTO);
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
        public async Task<IActionResult> DeleteMenu(Guid id)
        {
            try
            {
                await _service.DeleteMenuAsync(id);
                return Ok("Menu has been deleted");
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
