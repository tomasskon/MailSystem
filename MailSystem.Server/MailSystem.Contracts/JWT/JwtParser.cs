using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using MailSystem.Contracts.Enums;

namespace MailSystem.Contracts.JWT
{
    public static class JwtParser
    {
        public static Guid? GetUserId(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(jwtToken);
            var claim = jwtSecurityToken.Claims.First(c => c.Type == "UserId").Value;

            if (Guid.TryParse(claim, out var userId))
                return userId;

            return null;
        }

        public static UserType? GetUserType(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(jwtToken);
            var claim = jwtSecurityToken.Claims.First(c => c.Type == "UserType").Value;

            if (Enum.TryParse<UserType>(claim, out var userType))
                return userType;

            return null;
        }
    }
}