using System;
using MailSystem.Domain.Enums;

namespace MailSystem.Services.Interfaces
{
    public interface ITokenService
    {
        string GetJwtToken(Guid userId, UserType userType);
    }
}