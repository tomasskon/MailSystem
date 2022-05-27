using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MailSystem.Contracts.Shipment;
using MailSystem.Http.Interfaces;

namespace MailSystem.Http.HttpClients
{
    public class ShipmentHttpClient : IShipmentHttpClient
    {
        private readonly IAuthorizedHttpClient _authorizedHttpClient;

        public ShipmentHttpClient(IAuthorizedHttpClient authorizedHttpClient)
        {
            _authorizedHttpClient = authorizedHttpClient;
        }

        public async Task<IEnumerable<ShipmentContract>> GetUserShipments(Guid userId)
        {
            using var client = await _authorizedHttpClient.CreateHttpClient();
            var response = await client.GetAsync("Shipments/GetUserShipments?userId=" + userId);

            return await _authorizedHttpClient.HandleResponse<IEnumerable<ShipmentContract>>(response);
        }

        public async Task<string> RegisterShipment(RegisterShipmentContract registerShipmentContract)
        {
            using var client = await _authorizedHttpClient.CreateHttpClient();
            var response = await client.PostAsJsonAsync("Shipments/RegisterShipment", registerShipmentContract);

            return await _authorizedHttpClient.HandleStringResponse(response);
        }
    }
}