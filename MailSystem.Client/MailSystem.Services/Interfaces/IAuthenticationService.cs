using System.Threading.Tasks;
using MailSystem.Contracts.Authentication;

namespace MailSystem.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GetJwtToken();

        Task OnlyAuthenticated();

        Task OnlyUser();

        Task OnlyCourier();

        Task OnlyGuest();

        Task Login(string jwtToken);

        Task Logout();
    }
}