using AutoMapper;
using FoodOrdering.Application.Dtos.Order;
using FoodOrdering.Application.Services.OrderService;
using FoodOrdering.Presentation.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FoodOrdering.Presentation.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        private readonly IMapper _mapper;

        public OrderController(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("place")]
        public async Task<IActionResult> PlaceOrder(Guid basketId, PlaceOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                PlaceOrderDto dto = _mapper.Map<PlaceOrderDto>(model);
                try
                {
                    await _service.Place(basketId, dto);
                    return Ok("Order has been placed");
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Model not valid");
            }
        }

        [HttpPut("accept")]
        public async Task<IActionResult> AcceptOrder(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id is empty");
            }

            try
            {
                await _service.Accept(id);
                return Ok("Order has  been accepted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("cancel")]
        public async Task<IActionResult> CancelOrder(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id is empty");
            }

            try
            {
                await _service.Cancel(id);
                return Ok("Order has  been canceled");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
