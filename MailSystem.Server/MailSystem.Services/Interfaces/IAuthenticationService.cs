using MailSystem.Domain.Models;

namespace MailSystem.Services.Interfaces
{
    public interface IAuthenticationService
    {
        string CourierLogin(string emailAddress, string password);

        string CourierRegister(Courier courier, string password);
        
        string UserLogin(string emailAddress, string password);

        string UserRegister(User user, string password);
    }
}