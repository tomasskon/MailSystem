using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Contracts.User;

namespace MailSystem.Http.Interfaces
{
    public interface IUserHttpClient
    {
        Task<IEnumerable<UserContract>> GetUsers();
    }
}