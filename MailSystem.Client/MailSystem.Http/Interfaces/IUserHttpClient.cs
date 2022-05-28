using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Contracts.Users;

namespace MailSystem.Http.Interfaces
{
    public interface IUserHttpClient
    {
        Task<UserContract> GetUser(Guid userId);

        Task UpdateUser(UserContract user);
    }
}