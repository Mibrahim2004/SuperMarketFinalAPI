using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Application.DTOs.InventoryDTOs;
using SuperMarket.Application.Interfaces.IServices;

namespace SuperMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _inventoryService.GetAllInventories();
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _inventoryService.GetInventoryById(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> Create(InventoryCreateDTO createInventoryDTO)
        {
            var response = await _inventoryService.CreateInventory(createInventoryDTO);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _inventoryService.DeleteInventory(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> Update(InventoryUpdateDTO updateInventoryDTO, int id)
        {
            var response = await _inventoryService.UpdateInventory(updateInventoryDTO, id);
            return StatusCode(response.StatusCode, response);
        }
    }
}