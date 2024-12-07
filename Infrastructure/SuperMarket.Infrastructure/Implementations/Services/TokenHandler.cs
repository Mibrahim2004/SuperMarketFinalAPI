using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SuperMarket.Application.DTOs.TokenDTOs;
using SuperMarket.Application.Interfaces.ITokenHandlers;
using SuperMarket.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Infrastructure.Implementations.Services
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<AppUser> userManager;
        public TokenHandler(IConfiguration config, UserManager<AppUser> manager)
        {
            configuration = config;
            userManager = manager;
        }  
        public async Task<TokenDTO> CreateAccessToken(AppUser user)
        {
            TokenDTO tokenDTO = new TokenDTO();
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim (ClaimTypes.Name,user.UserName ),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var roles = await userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => (new Claim(ClaimTypes.Role, role))));

            tokenDTO.ExpirationTime = DateTime.UtcNow.AddMinutes(1);
            JwtSecurityToken securityToken = new JwtSecurityToken(
                audience: configuration["Token:Audience"],
                issuer: configuration["Token:Issuer"],
                expires: tokenDTO.ExpirationTime,
                signingCredentials: signingCredentials,
                claims: claims
                );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            tokenDTO.AccessToken = tokenHandler.WriteToken(securityToken);
            tokenDTO.RefreshToken = CreateRefreshToken();
            return tokenDTO;
        }
        public string CreateRefreshToken()
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Token:RefreshTokenSecret"]);// Refresh token için gizli sifre
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var refreshToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(refreshToken);
        }
    }
}
