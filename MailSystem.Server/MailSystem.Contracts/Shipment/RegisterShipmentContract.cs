using System;

namespace MailSystem.Contracts.Shipment
{
    public class RegisterShipmentContract
    {
        public Guid UserId { get; set; }
        
        public string Description { get; set; }
        
        public string ReceiverFullName { get; set; }
        
        public string ReceiverEmail { get; set; }
        
        public string ReceiverPhoneNumber { get; set; }
        
        public Guid MailBoxId { get; set; }
        
        public Guid ShipmentSizeId { get; set; }
    }
}