using SuperMarket.Application.DTOs.TokenDTOs;
using SuperMarket.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Interfaces.ITokenHandlers
{
    public interface ITokenHandler
    {
        Task<TokenDTO> CreateAccessToken(AppUser user);
        string CreateRefreshToken();
    }
}
