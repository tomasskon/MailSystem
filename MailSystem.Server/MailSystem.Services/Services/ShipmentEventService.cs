using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Domain.Enums;
using MailSystem.Domain.Models;
using MailSystem.Exception;
using MailSystem.Repositories.Interfaces;
using MailSystem.Services.Interfaces;

namespace MailSystem.Services.Services
{
    public class ShipmentEventService : IShipmentEventService
    {
        private readonly IShipmentEventRepository _shipmentEventRepository;

        public ShipmentEventService(IShipmentEventRepository shipmentEventRepository)
        {
            _shipmentEventRepository = shipmentEventRepository;
        }

        public async Task<List<DetailedShipmentEvent>> GetAllByTrackingId(string trackingId)
        {
            var shipmentEvents = await _shipmentEventRepository.GetAllByTrackingId(trackingId);

            if (shipmentEvents == null)
                throw new NoShipmentEventsFoundException($"No shipment events found for tracking id: {trackingId}");

            return shipmentEvents;
        }

        public async Task CreateShipmentEvent(Guid shipmentId, Guid? mailboxId, ShipmentStatus shipmentStatus)
        {
            var shipment = new ShipmentEvent {MailboxId = mailboxId, ShipmentStatus = shipmentStatus, ShipmentId = shipmentId};

            await _shipmentEventRepository.Create(shipment);
        }
    }
}