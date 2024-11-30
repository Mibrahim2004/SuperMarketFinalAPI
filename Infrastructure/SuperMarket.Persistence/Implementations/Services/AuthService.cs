using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
         public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }
        public async Task<ResponseModel<TokenDTO>> LoginAsync(string userNameOrEmail, string password)
        {
            ResponseModel<TokenDTO> responseModel = new ResponseModel<TokenDTO>()
            {
                Data = null,
                StatusCode= 400
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
                    responseModel.StatusCode= 500;
                }
                SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);//bir nece defe sehv giris bas vererse, hesabi kilidlememek ucun bu parametri false edirik.
                if (result.Succeeded)
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
                if (user != null && user?.ExpiredTime > DateTime.UtcNow)
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

        public async Task<ResponseModel<bool>> LogOut(string userNameorEmail)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                AppUser user = await _userManager.FindByNameAsync(userNameorEmail);
                if (user == null)
                {
                    user = await _userManager.FindByEmailAsync(userNameorEmail);
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

        public async Task<ResponseModel<bool>> PasswordResetAsync(string userNameorEmail, string currentpassword, string newpassword)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                AppUser user = await _userManager.FindByEmailAsync(userNameorEmail);
                if (user == null)
                {
                    user = await _userManager.FindByNameAsync(userNameorEmail);
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