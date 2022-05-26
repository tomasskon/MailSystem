using System.Threading.Tasks;
using MailSystem.Contracts.Authentication;

namespace MailSystem.Http.Interfaces
{
    public interface IAuthenticationHttpClient
    {
        Task<string> UserLogin(UserLoginContract userLoginContract);

        Task<string> CourierLogin(CourierLoginContract courierLoginContract);

        Task<string> UserRegister(UserRegisterContract userRegisterContract);

        Task<string> CourierRegister(CourierRegisterContract courierRegisterContract);
    }
}