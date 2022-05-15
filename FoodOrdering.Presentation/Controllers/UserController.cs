using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using AutoMapper;

using FoodOrdering.Application.Dtos.User;
using FoodOrdering.Presentation.ViewModels.User;
using FoodOrdering.Application.Services.UserService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodOrdering.Presentation.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }

            var registerDto = _mapper.Map<RegisterDto>(registerViewModel);
            await _userService.Register(registerDto);
            return Ok("Registration is succesfull");
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }

            var loginDto = _mapper.Map<LoginDto>(loginViewModel);
            var token = await _userService.Login(loginDto);

            return Ok(token);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var allUsersListDto = await _userService.GetAll();
            var allUsersListViewModel = _mapper.Map <List<GetAllUsersViewModel>>(allUsersListDto);
            return Ok(allUsersListViewModel);

        }
    
        [HttpGet("get")]
        public async Task<IActionResult> Get(Guid id)
        {
            var userDto = await _userService.Get(id);
            var userViewModel = _mapper.Map<GetUserViewModel>(userDto);
            return Ok(userViewModel);

        }

        [HttpPut("appoint-as-cook")]
        public async Task<IActionResult> AppointAsCook(Guid id)
        {
            await _userService.AppointAsCook(id);
            return Ok("User appointed as cook");
        }

        [HttpPut("appoint-as-manager")]
        public async Task<IActionResult> AppointAsManager(Guid id)
        {
            await _userService.AppointAsManager(id);
            return Ok("User appointed as manager");
        }

        [HttpPut("appoint-as-employee")]
        public async Task<IActionResult> AppointAsEmployee(Guid id)
        {
            await _userService.AppointAsEmployee(id);
            return Ok("User appointed as employee");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userService.Delete(id);
            return Ok("User has been deleted");
        }
    }
}
