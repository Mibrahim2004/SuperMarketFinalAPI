using SuperMarket.Application.DTOs.UserDTOs;
using SuperMarket.Application.Models;
using SuperMarket.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Interfaces.IServices
{
    public interface IUserService
    {
        Task<ResponseModel<CreateUserResponseDTO>> CreateAsync(CreateUserDTO model);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate);
        public Task<ResponseModel<List<GetUserDTO>>> GetAllUsersAsync();
        public Task<ResponseModel<bool>> AssignRoleToUserAsync(string userId, string[] roles);
        public Task<ResponseModel<string[]>> GetRolesToUserAsync(string userIdOrName);
        public Task<ResponseModel<bool>> DeleteUserAsync(string userIdOrName);
        public Task<ResponseModel<bool>> UpdateUserAsync(UpdateUserDTO model);
    }
}
