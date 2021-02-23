using Microsoft.IdentityModel.Tokens;
using SixConsultApi.Helpers.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SixConsultApi.Helpers
{
    public class JwtService : IJwtService
    {
        public string GenerateJwtToken(string secret, string claimId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, claimId)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)), SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenHandler.CreateToken(tokenDescriptor).ToString();
        }
    }
}
