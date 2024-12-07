using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SuperMarket.Application.DTOs.TokenDTOs;
using SuperMarket.Application.Interfaces.IServices;
using SuperMarket.Application.Interfaces.ITokenHandlers;
using SuperMarket.Application.Models;
using SuperMarket.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.Implementations.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IUserService _userService;
        readonly IConfiguration _configuration;
        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IUserService userService, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
            _configuration = configuration;
        }
        public async Task<ResponseModel<TokenDTO>> LoginAsync(string userNameOrEmail, string password)
        {
            ResponseModel<TokenDTO> responseModel = new()
            { Data = null, StatusCode = 400 };
            var user = await _userManager.FindByNameAsync(userNameOrEmail);
            if (user == null)
            {
                responseModel.StatusCode = 404;
                return responseModel;
            }
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);//bir nece defe sehv giris bas vererse, hesabi locklamamaq ucun bu parametri false edirik
            if (result.Succeeded)
            {
                TokenDTO tokenDTO = await _tokenHandler.CreateAccessToken(user);
                var minsString = _configuration["Token:RefreshTokenExpirationInMinutes"];
                var mins = Convert.ToDouble(minsString);
                await _userService.UpdateRefreshToken(tokenDTO.RefreshToken, user, tokenDTO.ExpirationTime.AddMinutes(mins));
                responseModel.Data = tokenDTO;
                responseModel.StatusCode = 200;
            }
            else
            {
                responseModel.StatusCode = 401;
            }
            return responseModel;
        }
        public async Task<ResponseModel<TokenDTO>> LoginWithRefreshTokenAsync(string refreshToken)
        {
            ResponseModel<TokenDTO> responseModel = new ResponseModel<TokenDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                AppUser? user = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
                if (user != null && user?.RefreshTokenEndTime > DateTime.UtcNow)
                {
                    TokenDTO tokenDTO = await _tokenHandler.CreateAccessToken(user);
                    await _userService.UpdateRefreshToken(tokenDTO.RefreshToken, user, tokenDTO.ExpirationTime);
                    responseModel.Data = tokenDTO;
                    responseModel.StatusCode = 200;
                }
                else
                {
                    responseModel.StatusCode = 401;
                }
            }
            catch
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<bool>> LogOut(string userNameOrEmail)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                AppUser user = await _userManager.FindByNameAsync(userNameOrEmail);
                if (user == null)
                {
                    user = await _userManager.FindByEmailAsync(userNameOrEmail);
                }
                else
                {
                    responseModel.StatusCode = 500;
                }
                var result = await _userManager.UpdateAsync(user);
                await _signInManager.SignOutAsync();
                if (result.Succeeded)
                {
                    responseModel.Data = true;
                    responseModel.StatusCode = 200;
                }
                else
                {
                    responseModel.StatusCode = 401;
                }
            }
            catch
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<bool>> PasswordResetAsync(string userNameOrEmail, string currentpassword, string newpassword)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                AppUser user = await _userManager.FindByEmailAsync(userNameOrEmail);
                if (user == null)
                {
                    user = await _userManager.FindByNameAsync(userNameOrEmail);
                }
                else
                {
                    var data = await _userManager.ChangePasswordAsync(user, currentpassword, newpassword);
                    if (data.Succeeded)
                    {
                        responseModel.Data = true;
                        responseModel.StatusCode = 200;
                    }
                    else
                    {
                        responseModel.StatusCode = 401;
                    }
                }
            }
            catch
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }
    }
}