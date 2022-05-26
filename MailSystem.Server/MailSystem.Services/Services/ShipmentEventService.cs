using System;
using System.Collections.Generic;
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

        public List<DetailedShipmentEvent> GetAllByTrackingId(string trackingId)
        {
            var shipmentEvents = _shipmentEventRepository.GetAllByTrackingId(trackingId);

            if (shipmentEvents == null)
                throw new NoShipmentEventsFoundException($"No shipment events found for tracking id: {trackingId}");

            return shipmentEvents;
        }

        public void CreateShipmentEvent(Guid mailboxId, ShipmentStatus shipmentStatus, string trackingId)
        {
            var shipment = new ShipmentEvent {MailboxId = mailboxId, ShipmentStatus = shipmentStatus, TrackingId = trackingId};

            _shipmentEventRepository.Create(shipment);
        }
    }
}