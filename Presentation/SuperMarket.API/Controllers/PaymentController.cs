using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Application.DTOs.PaymentDTOs;
using SuperMarket.Application.Interfaces.IServices;

namespace SuperMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _paymentService.GetAllPayments();
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _paymentService.GetPaymentById(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> Create(PaymentCreateDTO createPaymentDTO)
        {
            var response = await _paymentService.CreatePayment(createPaymentDTO);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _paymentService.DeletePayment(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> Update(PaymentUpdateDTO updatePaymentDTO, int id)
        {
            var response = await _paymentService.UpdatePayment(updatePaymentDTO, id);
            return StatusCode(response.StatusCode, response);
        }
    }
}