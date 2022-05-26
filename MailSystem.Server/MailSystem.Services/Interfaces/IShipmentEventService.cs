using System;
using System.Collections.Generic;
using MailSystem.Domain.Enums;
using MailSystem.Domain.Models;

namespace MailSystem.Services.Interfaces
{
    public interface IShipmentEventService
    {
        List<DetailedShipmentEvent> GetAllByTrackingId(string trackingId);

        void CreateShipmentEvent(Guid? mailboxId, ShipmentStatus shipmentStatus, string trackingId);
    }
}