using System;
using System.Reflection;
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

        public ShipmentService(IUserService userService, IMailboxService mailboxService, IShipmentSizeService shipmentSizeService, IShipmentRepository shipmentRepository)
        {
            _userService = userService;
            _mailboxService = mailboxService;
            _shipmentSizeService = shipmentSizeService;
            _shipmentRepository = shipmentRepository;
        }

        public Guid CreateShipment(Shipment shipment)
        {
            _userService.CheckIfUserExists(shipment.UserId);
            _mailboxService.CheckIfMailboxExists(shipment.MailBoxId);
            _shipmentSizeService.CheckIfShipmentSizeExists(shipment.ShipmentSizeId);

            return _shipmentRepository.Create(shipment);
        }
    }
}