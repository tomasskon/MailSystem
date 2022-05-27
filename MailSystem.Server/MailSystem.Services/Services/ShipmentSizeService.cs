using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Domain.Models;
using MailSystem.Exception;
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

        public async Task<IEnumerable<ShipmentSize>> GetAll()
        {
            return await _shipmentSizeRepository.GetAll();
        }

        public async Task CheckIfShipmentSizeExists(Guid shipmentSizeId)
        {
            if (!await _shipmentSizeRepository.CheckIfExists(shipmentSizeId))
                throw new ShipmentSizeNotFoundException($"Shipment size not found. Shipment size id:{shipmentSizeId}");
        }
    }
}