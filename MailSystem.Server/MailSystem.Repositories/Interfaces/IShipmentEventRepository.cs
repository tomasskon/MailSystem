using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Domain.Models;

namespace MailSystem.Repositories.Interfaces
{
    public interface IShipmentEventRepository
    {
        Task<List<DetailedShipmentEvent>> GetAllByTrackingId(string trackingId);

        Task<Guid> Create(ShipmentEvent shipmentEvent);
    }
}