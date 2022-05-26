using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Contracts.ShipmentSizes;
using MailSystem.Http.Interfaces;

namespace MailSystem.Http.HttpClients
{
    public class ShipmentSizeHttpClient : IShipmentSizeHttpClient
    {
        private readonly IAuthorizedHttpClient _authorizedHttpClient;

        public ShipmentSizeHttpClient(IAuthorizedHttpClient authorizedHttpClient)
        {
            _authorizedHttpClient = authorizedHttpClient;
        }
        
        public async Task<IEnumerable<ShipmentSizeContract>> GetShipmentSizes()
        {
            using var client = await _authorizedHttpClient.CreateHttpClient();
            var response = await client.GetAsync("ShipmentSizes/GetShipmentSizes");

            return await _authorizedHttpClient.HandleResponse<IEnumerable<ShipmentSizeContract>>(response);
        }
    }
}