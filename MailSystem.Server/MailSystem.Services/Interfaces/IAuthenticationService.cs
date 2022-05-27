using System.Threading.Tasks;
using MailSystem.Domain.Models;

namespace MailSystem.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> CourierLogin(string emailAddress, string password);

        Task<string> CourierRegister(Courier courier, string password);
        
        Task<string> UserLogin(string emailAddress, string password);

        Task<string> UserRegister(User user, string password);
    }
}