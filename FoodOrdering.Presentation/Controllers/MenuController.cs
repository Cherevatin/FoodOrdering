using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using AutoMapper;

using FoodOrdering.Application.Dtos.Menu;
using FoodOrdering.Presentation.ViewModels.Menu;
using FoodOrdering.Application.Services.MenuService;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodOrdering.Presentation.Controllers
{
    [Route("api/menu")]
    [ApiController]
    [Authorize(Roles = "Manager, Cook")]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;
        public MenuController(IMenuService menuService, IMapper mapper)
        {
            _menuService = menuService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddMenu(AddMenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                AddMenuDto dto = _mapper.Map<AddMenuDto>(model);

                await _menuService.Add(dto);

                return Ok("Menu has been created");
            }
            else
            {
                return BadRequest("Model not valid");
            }
            
        }

        [HttpGet("get-all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllMenus()
        {
            var allMenusDto = await _menuService.GetAll();
            var allMenusViewModel = _mapper.Map<List<GetAllMenusViewModel>>(allMenusDto);
            return Ok(allMenusViewModel);
        }

        [HttpGet("get")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMenu(Guid menuId)
        {
            var dto = await _menuService.Get(menuId);
            var viewModel = _mapper.Map<GetMenuViewModel>(dto);

            return Ok(viewModel);
        }

        [HttpPut("add-dish")]
        public async Task<IActionResult> AddDish(Guid menuId, AddDishToMenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                AddDishToMenuDto dto = _mapper.Map<AddDishToMenuDto>(model);

                await _menuService.AddDish(menuId, dto);
                return Ok("Dish has been added");
            }
            else
            {
                return BadRequest("Model not valid");
            }
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditMenu(Guid menuId, EditMenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                UpdateMenuDto dto = _mapper.Map<UpdateMenuDto>(model);
  
                await _menuService.Update(menuId, dto);
                return Ok("Menu has been updated");
            }
            else
            {
                return BadRequest("Model not valid");
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteMenu(Guid menuId)
        {
            await _menuService.Delete(menuId);
            return Ok("Menu has been deleted");
        }
    }
}
