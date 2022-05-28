using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MailSystem.Contracts.Couriers;
using MailSystem.Http.Interfaces;

namespace MailSystem.Http.HttpClients
{
    public class CourierHttpClient : ICourierHttpClient
    {
        private readonly IAuthorizedHttpClient _authorizedHttpClient;

        public CourierHttpClient(IAuthorizedHttpClient authorizedHttpClient)
        {
            _authorizedHttpClient = authorizedHttpClient;
        }

        public async Task<CourierContract> GetCourier(Guid courierId)
        {
            using var client = await _authorizedHttpClient.CreateHttpClient();
            var response = await client.GetAsync("Courier/GetCourier?courierId=" + courierId);

            return await _authorizedHttpClient.HandleResponse<CourierContract>(response);
        }

        public async Task UpdateCourier(CourierContract user)
        {
            using var client = await _authorizedHttpClient.CreateHttpClient();
            var response = await client.PutAsJsonAsync("Courier/UpdateCourier", user);

            await _authorizedHttpClient.HandleResponse(response);
        }
    }
}