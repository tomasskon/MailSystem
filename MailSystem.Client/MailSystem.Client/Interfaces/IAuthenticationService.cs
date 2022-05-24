using System.Threading.Tasks;

namespace MailSystem.Client.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GetJWTToken();
        Task<bool> OnlyAuthenticated();
        Task<bool> OnlyGuest();
        Task<bool> IsAuthenticated();
        Task Login(string username, string password);
        Task Logout();
    }
}