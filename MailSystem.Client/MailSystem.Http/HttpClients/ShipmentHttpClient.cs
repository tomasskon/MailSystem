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

        public async Task RegisterShipment(RegisterShipmentContract registerShipmentContract)
        {
            using var client = await _authorizedHttpClient.CreateHttpClient();
            var response = await client.PostAsJsonAsync("Shipments/RegisterShipment", registerShipmentContract);

            await _authorizedHttpClient.HandleResponse(response);
        }
    }
}