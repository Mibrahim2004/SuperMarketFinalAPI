using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Application.DTOs.UserDTOs;
using SuperMarket.Application.Interfaces.IServices;

namespace SuperMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userService.GetAllUsersAsync();
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO model)
        {
            var response = await _userService.CreateAsync(model);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> Delete(string userIdOrName)
        {
            var response = await _userService.DeleteUserAsync(userIdOrName);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> Update(UpdateUserDTO model)
        {
            var response = await _userService.UpdateUserAsync(model);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("get-roles-to-user")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetRolesToUser(string userIdOrName)
        {
            var response = await _userService.GetRolesToUserAsync(userIdOrName);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost("assign-role-to-user")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> AssignRoleToUser(string userId, string[] roles)
        {
            var response = await _userService.AssignRoleToUserAsync(userId, roles);
            return StatusCode(response.StatusCode, response);
        }
    }
}