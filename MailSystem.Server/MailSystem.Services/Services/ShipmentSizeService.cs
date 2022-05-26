using System;
using System.Collections.Generic;
using MailSystem.Domain.Exceptions;
using MailSystem.Domain.Models;
using MailSystem.Repositories.Interfaces;
using MailSystem.Services.Interfaces;

namespace MailSystem.Services.Services
{
    public class ShipmentSizeService : IShipmentSizeService
    {
        private readonly IShipmentSizeRepository _shipmentSizeRepository;

        public ShipmentSizeService(IShipmentSizeRepository shipmentSizeRepository)
        {
            _shipmentSizeRepository = shipmentSizeRepository;
        }

        public IEnumerable<ShipmentSize> GetAll()
        {
            return _shipmentSizeRepository.GetAll();
        }

        public void CheckIfShipmentSizeExists(Guid shipmentSizeId)
        {
            if (!_shipmentSizeRepository.CheckIfExists(shipmentSizeId))
                throw new ShipmentSizeNotFoundException($"Shipment size not found. Shipment size id:{shipmentSizeId}");
        }
    }
}