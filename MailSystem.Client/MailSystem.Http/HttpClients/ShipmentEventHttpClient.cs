using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Contracts.ShipmentEvents;
using MailSystem.Http.Interfaces;

namespace MailSystem.Http.HttpClients
{
    public class ShipmentEventHttpClient : IShipmentEventHttpClient
    {
        private readonly IAuthorizedHttpClient _authorizedHttpClient;

        public ShipmentEventHttpClient(IAuthorizedHttpClient authorizedHttpClient)
        {
            _authorizedHttpClient = authorizedHttpClient;
        }

        public async Task<IEnumerable<DetailedShipmentEventContract>> GetEventsByTrackingId(string trackingId)
        {
            using var client = await _authorizedHttpClient.CreateHttpClient();
            var response = await client.GetAsync("ShipmentEvents/GetEventsByTrackingId?trackingId=" + trackingId);

            return await _authorizedHttpClient.HandleResponse<IEnumerable<DetailedShipmentEventContract>>(response);
        }
    }
}