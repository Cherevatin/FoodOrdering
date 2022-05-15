using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using AutoMapper;

using FoodOrdering.Application.Dtos.Order;
using FoodOrdering.Application.Services.OrderService;
using FoodOrdering.Presentation.ViewModels;

namespace FoodOrdering.Presentation.Controllers
{
    [Route("api/order")]
    [ApiController]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost("place")]
        public async Task<IActionResult> PlaceOrder(Guid basketId, [FromBody] PlaceOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                PlaceOrderDto dto = _mapper.Map<PlaceOrderDto>(model);
           
                await _orderService.Place(basketId, dto);
                return Ok("Order has been placed");
            }
            else
            {
                return BadRequest("Model not valid");
            }
        }

        [HttpPut("accept")]
        [Authorize(Roles = "Cook")]
        public async Task<IActionResult> AcceptOrder(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id is empty");
            }

            await _orderService.Accept(id);
            return Ok("Order has  been accepted");
     
        }

        [HttpPut("cancel")]
        [Authorize(Roles = "Cook")]
        public async Task<IActionResult> CancelOrder(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id is empty");
            }

            await _orderService.Cancel(id);
            return Ok("Order has  been canceled");
        }
    }
}
