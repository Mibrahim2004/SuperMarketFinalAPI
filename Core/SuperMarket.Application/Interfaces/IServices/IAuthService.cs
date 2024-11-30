using SuperMarket.Application.DTOs.TokenDTOs;
using SuperMarket.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Interfaces.IServices
{
    public interface IAuthService
    {
        Task<ResponseModel<TokenDTO>> LoginAsync(string userNameOrEmail, string password);
        Task<ResponseModel<TokenDTO>> LoginWithRefreshTokenAsync(string refreshToken);
        Task<ResponseModel<bool>> LogOut(string userNameOrEmail);
        Task<ResponseModel<bool>> PasswordResetAsync(string userNameorEmail, string currentpassword, string newpassword);
    }
}
