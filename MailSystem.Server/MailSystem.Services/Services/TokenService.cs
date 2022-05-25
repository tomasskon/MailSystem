using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MailSystem.Domain.Configurations;
using MailSystem.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace MailSystem.Services.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtTokenConfiguration _jwtConfiguration;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public TokenService(JwtTokenConfiguration jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration;

            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public string GetJwtToken()
        {
            var tokenKey = Encoding.UTF8.GetBytes(_jwtConfiguration.Key);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = _tokenHandler.CreateToken(tokenDescriptor);
            return _tokenHandler.WriteToken(token);
        }
    }
}