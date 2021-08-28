using ApplicationCore.Interfaces.ISecurity;
using ApplicationCore.Interfaces.IServices;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Security
{
    public class JwtService : ITokenClaimsService
    {
        private readonly IUserService _userService;
        public JwtService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string> GetTokenAsync(int userId, string key)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.ASCII.GetBytes(key);
            var user = await _userService.GetUserById(userId);
            
            var claims = new List<Claim> { new Claim("UserId", user.Id.ToString()) };
            claims.Add(new Claim("RoleId", user.RoleId.ToString()));
            claims.Add(new Claim("PortalId", user.PortalId.ToString()));
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
