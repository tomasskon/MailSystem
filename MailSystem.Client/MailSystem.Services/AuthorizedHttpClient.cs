using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MailSystem.Services.Interfaces;

namespace MailSystem.Services
{
    public class AuthorizedHttpClient : IAuthorizedHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAuthenticationService _authenticationService;

        public AuthorizedHttpClient(IHttpClientFactory httpClientFactory, IAuthenticationService authenticationService)
        {
            _httpClientFactory = httpClientFactory;
            _authenticationService = authenticationService;
        }

        public async Task<HttpClient> CreateHttpClient()
        {
            var httpClient = _httpClientFactory.CreateClient("Server");
            var jwtToken = await _authenticationService.GetJwtToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            return httpClient;
        }
    }
}