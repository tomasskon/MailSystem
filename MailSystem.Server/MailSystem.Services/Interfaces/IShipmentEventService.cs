using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Domain.Enums;
using MailSystem.Domain.Models;

namespace MailSystem.Services.Interfaces
{
    public interface IShipmentEventService
    {
        Task<List<DetailedShipmentEvent>> GetAllByTrackingId(string trackingId);

        Task CreateShipmentEvent(Guid? mailboxId, ShipmentStatus shipmentStatus, string trackingId);
    }
}