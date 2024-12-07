using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Application.Interfaces.IServices;

namespace SuperMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(string userNameOrEmail, string password)
        {
            var data = await _authService.LoginAsync(userNameOrEmail, password);
            return StatusCode(data.StatusCode, data);
        }

        [HttpPost("login-with-refresh-token")]
        public async Task<IActionResult> LoginWithRefreshTokenAsync(string refreshToken)
        {
            var data = await _authService.LoginWithRefreshTokenAsync(refreshToken);
            return StatusCode(data.StatusCode, data);
        }

        [HttpPut("logout")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> LogOut(string userNameOrEmail)
        {
            var data = await _authService.LogOut(userNameOrEmail);
            return StatusCode(data.StatusCode, data);
        }

        [HttpPost("password-reset")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> PasswordResetAsync(string userNameOrEmail, string currentpassword, string newpassword)
        {
            var data = await _authService.PasswordResetAsync(userNameOrEmail, currentpassword, newpassword);
            return StatusCode(data.StatusCode, data);
        }
    }
}