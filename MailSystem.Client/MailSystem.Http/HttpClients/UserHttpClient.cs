using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MailSystem.Contracts.Users;
using MailSystem.Http.Interfaces;

namespace MailSystem.Http.HttpClients
{
    public class UserHttpClient : IUserHttpClient
    {
        private readonly IHttpClientFactory _clientFactory;

        public UserHttpClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<UserContract>> GetUsers()
        {
            using var client = _clientFactory.CreateClient("Server");
            var response = await client.GetAsync("Users/GetUsers");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<UserContract>>();

            return null;
        }
    }
}