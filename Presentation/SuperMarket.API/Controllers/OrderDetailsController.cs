using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Application.DTOs.OrderDetailsDTOs;
using SuperMarket.Application.Interfaces.IServices;

namespace SuperMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _orderdetailsService;
        public OrderDetailsController(IOrderDetailsService orderdetailsService)
        {
            _orderdetailsService = orderdetailsService;
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _orderdetailsService.GetAllOrderDetails();
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _orderdetailsService.GetOrderDetailsById(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> Create(OrderDetailsCreateDTO createOrderDetailsDTO)
        {
            var response = await _orderdetailsService.CreateOrderDetails(createOrderDetailsDTO);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _orderdetailsService.DeleteOrderDetails(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> Update(OrderDetailsUpdateDTO updateOrderDetailsDTO, int id)
        {
            var response = await _orderdetailsService.UpdateOrderDetails(updateOrderDetailsDTO, id);
            return StatusCode(response.StatusCode, response);
        }
    }
}