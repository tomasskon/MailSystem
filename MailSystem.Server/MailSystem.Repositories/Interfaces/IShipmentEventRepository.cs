using System;
using System.Collections.Generic;
using MailSystem.Domain.Models;

namespace MailSystem.Repositories.Interfaces
{
    public interface IShipmentEventRepository
    {
        List<DetailedShipmentEvent> GetAllByTrackingId(string trackingId);

        Guid Create(ShipmentEvent shipmentEvent);
    }
}