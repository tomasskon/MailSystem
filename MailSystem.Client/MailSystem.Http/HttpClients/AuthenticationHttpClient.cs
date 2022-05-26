using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MailSystem.Contracts;
using MailSystem.Contracts.Authentication;
using MailSystem.Http.Exceptions;
using MailSystem.Http.Interfaces;

namespace MailSystem.Http.HttpClients
{
    public class AuthenticationHttpClient : IAuthenticationHttpClient
    {
        private readonly IHttpClientFactory _clientFactory;

        public AuthenticationHttpClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> UserLogin(UserLoginContract userLoginContract)
        {
            using var client = _clientFactory.CreateClient("Server");
            var response = await client.PostAsJsonAsync("Authentication/UserLogin", userLoginContract);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            var errorResponse = await response.Content.ReadFromJsonAsync<StandardExceptionResponse>();

            throw new ServerRequestException(errorResponse?.Exception, errorResponse?.Message);
        }

        public async Task<string> CourierLogin(CourierLoginContract courierLoginContract)
        {
            using var client = _clientFactory.CreateClient("Server");
            var response = await client.PostAsJsonAsync("Authentication/CourierLogin", courierLoginContract);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            var errorResponse = await response.Content.ReadFromJsonAsync<StandardExceptionResponse>();

            throw new ServerRequestException(errorResponse?.Exception, errorResponse?.Message);
        }

        public async Task<string> UserRegister(UserRegisterContract userRegisterContract)
        {
            using var client = _clientFactory.CreateClient("Server");
            var response = await client.PostAsJsonAsync("Authentication/UserRegister", userRegisterContract);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            var errorResponse = await response.Content.ReadFromJsonAsync<StandardExceptionResponse>();

            throw new ServerRequestException(errorResponse?.Exception, errorResponse?.Message);
        }

        public async Task<string> CourierRegister(CourierRegisterContract courierRegisterContract)
        {
            using var client = _clientFactory.CreateClient("Server");
            var response = await client.PostAsJsonAsync("Authentication/CourierRegister", courierRegisterContract);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            var errorResponse = await response.Content.ReadFromJsonAsync<StandardExceptionResponse>();

            throw new ServerRequestException(errorResponse?.Exception, errorResponse?.Message);
        }
    }
}