using System;

namespace MailSystem.Domain.Models
{
    public class Shipment
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }
        
        public string Description { get; set; }
        
        public string ReceiverFullName { get; set; }
        
        public string ReceiverEmail { get; set; }
        
        public string ReceiverPhoneNumber { get; set; }
        
        public Guid MailBoxId { get; set; }
        
        public Guid ShipmentSizeId { get; set; }
    }
}