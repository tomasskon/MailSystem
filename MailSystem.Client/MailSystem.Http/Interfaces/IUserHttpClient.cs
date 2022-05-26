using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Contracts.Users;

namespace MailSystem.Http.Interfaces
{
    public interface IUserHttpClient
    {
        Task<IEnumerable<UserContract>> GetUsers();
    }
}