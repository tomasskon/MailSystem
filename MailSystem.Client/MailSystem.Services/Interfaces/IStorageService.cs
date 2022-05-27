using System;
using System.Threading.Tasks;
using MailSystem.Contracts.Couriers;
using MailSystem.Contracts.Enums;
using MailSystem.Contracts.Users;

namespace MailSystem.Services.Interfaces
{
    public interface IStorageService
    {
        Task<string> GetJwtToken();

        Task SetJwtToken(string jwtToken);

        Task RemoveJwtToken();
        
        Task<UserContract> GetUserInfo();

        Task<CourierContract> GetCourierInfo();

        Task<UserType?> GetUserType();

        Task<Guid?> GetUserId();

        Task UpdateUserInfo();

        Task RemoveUserInfo();
    }
}