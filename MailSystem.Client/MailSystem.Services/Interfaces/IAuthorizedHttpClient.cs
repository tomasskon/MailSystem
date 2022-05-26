using System.Net.Http;
using System.Threading.Tasks;

namespace MailSystem.Services.Interfaces
{
    public interface IAuthorizedHttpClient
    {
        Task<HttpClient> CreateHttpClient();
    }
}