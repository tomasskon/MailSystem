using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace MailSystem.Http.Interfaces
{
    public interface IAuthorizedHttpClient
    {
        Task<HttpClient> CreateHttpClient();

        Task<T> HandleResponse<T>(HttpResponseMessage response);

        Task<string> HandleStringResponse(HttpResponseMessage response);

        Task<Stream> HandleStreamResponse(HttpResponseMessage response);

        Task HandleResponse(HttpResponseMessage response);
    }
}