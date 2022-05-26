using System.Threading.Tasks;

namespace MailSystem.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task OnlyAuthenticated();

        Task OnlyUser();

        Task OnlyCourier();

        Task OnlyGuest();

        Task Login(string jwtToken);

        Task Logout();
    }
}