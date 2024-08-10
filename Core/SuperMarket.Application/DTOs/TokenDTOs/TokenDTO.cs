using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.DTOs.TokenDTOs
{
    public class TokenDTO
    {
        public string AccessToken { get; set; }
        public DateTime ExpirationTime { get; set; }
        public string RefreshToken { get; set; }
    }
}
