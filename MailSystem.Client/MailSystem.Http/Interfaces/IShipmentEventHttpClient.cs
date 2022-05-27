using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Contracts.ShipmentEvents;

namespace MailSystem.Http.Interfaces
{
    public interface IShipmentEventHttpClient
    {
        Task<IEnumerable<DetailedShipmentEventContract>> GetEventsByTrackingId(string trackingId);
    }
}