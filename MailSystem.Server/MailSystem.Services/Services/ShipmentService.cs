using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MailSystem.Domain.Enums;
using MailSystem.Domain.Models;
using MailSystem.Exception;
using MailSystem.Repositories.Interfaces;
using MailSystem.Services.Interfaces;

namespace MailSystem.Services.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IUserService _userService;
        private readonly IMailboxService _mailboxService;
        private readonly IShipmentSizeService _shipmentSizeService;
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IShipmentEventService _shipmentEventService;
        
        public ShipmentService(IUserService userService, IMailboxService mailboxService, 
            IShipmentSizeService shipmentSizeService, IShipmentRepository shipmentRepository, IShipmentEventService shipmentEventService)
        {
            _userService = userService;
            _mailboxService = mailboxService;
            _shipmentSizeService = shipmentSizeService;
            _shipmentRepository = shipmentRepository;
            _shipmentEventService = shipmentEventService;
        }
        
        public async Task<List<DetailedShipment>> GetUserShipments(Guid userId)
        {
            await _userService.CheckIfUserExists(userId);
            var shipments = await _shipmentRepository.GetUserShipments(userId);

            if (shipments == null)
                throw new NoShipmentsFoundException($"No shipments found for user id: {userId}");

            return shipments;
        }

        public async Task<string> CreateShipment(Shipment shipment)
        {
            await _userService.CheckIfUserExists(shipment.UserId);
            await _mailboxService.CheckIfMailboxExists(shipment.MailBoxId);
            await _shipmentSizeService.CheckIfShipmentSizeExists(shipment.ShipmentSizeId);
            
            shipment.TrackingId = CreateTrackingId(); 
            var shipmentId = await _shipmentRepository.Create(shipment);
                
            await _shipmentEventService.CreateShipmentEvent(shipmentId, shipment.MailBoxId, ShipmentStatus.Submitted);

            return shipment.TrackingId;
        }

        private static string CreateTrackingId()
        {
            return "LT" + Ulid.NewUlid();
        }
    }
}