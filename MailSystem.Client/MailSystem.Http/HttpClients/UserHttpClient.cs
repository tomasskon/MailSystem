using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MailSystem.Contracts.Users;
using MailSystem.Http.Interfaces;

namespace MailSystem.Http.HttpClients
{
    public class UserHttpClient : IUserHttpClient
    {
        private readonly IAuthorizedHttpClient _authorizedHttpClient;

        public UserHttpClient(IAuthorizedHttpClient authorizedHttpClient)
        {
            _authorizedHttpClient = authorizedHttpClient;
        }

        public async Task<UserContract> GetUser(Guid userId)
        {
            using var client = await _authorizedHttpClient.CreateHttpClient();
            var response = await client.GetAsync("Users/GetUser?userId=" + userId);

            return await _authorizedHttpClient.HandleResponse<UserContract>(response);
        }

        public async Task UpdateUser(UserContract user)
        {
            using var client = await _authorizedHttpClient.CreateHttpClient();
            var response = await client.PutAsJsonAsync("Users/UpdateUser", user);

            await _authorizedHttpClient.HandleResponse(response);
        }
    }
}