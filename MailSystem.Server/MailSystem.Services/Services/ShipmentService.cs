using System;
using System.Text;
using System.Threading.Tasks;
using MailSystem.Domain.Enums;
using MailSystem.Domain.Models;
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

        public async Task<string> CreateShipment(Shipment shipment)
        {
            await _userService.CheckIfUserExists(shipment.UserId);
            await _mailboxService.CheckIfMailboxExists(shipment.MailBoxId);
            await _shipmentSizeService.CheckIfShipmentSizeExists(shipment.ShipmentSizeId);
            
            var shipmentId = await _shipmentRepository.Create(shipment);
            var trackingId = CreateTrackingId(shipmentId, shipment.UserId); 
                
            await _shipmentEventService.CreateShipmentEvent(shipment.MailBoxId, ShipmentStatus.Submitted, trackingId);

            return trackingId;
        }

        private static string CreateTrackingId(Guid shipmentId, Guid userId) {
            var plainTextBytes = Encoding.UTF8.GetBytes($"{shipmentId}{userId}");
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}