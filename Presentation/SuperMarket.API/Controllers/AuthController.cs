using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Application.Interfaces.IServices;

namespace SuperMarket.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> LoginAsync(string userNameOrEmail, string password)
        {
            var data = await _authService.LoginAsync(userNameOrEmail, password);
            return StatusCode(data.StatusCode, data);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> LoginWithRefreshTokenAsync(string refreshToken)
        {
            var data = await _authService.LoginWithRefreshTokenAsync(refreshToken);
            return StatusCode(data.StatusCode, data);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> LogOut(string userNameorEmail)
        {
            var data = await _authService.LogOut(userNameorEmail);
            return StatusCode(data.StatusCode, data);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> PasswordResetAsync(string userNameorEmail, string currentpas, string newpas)
        {
            var data = await _authService.PasswordResetAsync(userNameorEmail, currentpas, newpas);
            return StatusCode(data.StatusCode, data);
        }
    }
}