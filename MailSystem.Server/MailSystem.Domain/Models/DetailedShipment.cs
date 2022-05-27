using System;

namespace MailSystem.Domain.Models
{
    public class DetailedShipment
    {
        public Guid Id { get; set; }

        public string TrackingId { get; set; }
        
        public string Description { get; set; }
        
        public string ReceiverFullName { get; set; }
        
        public string ReceiverEmail { get; set; }
        
        public string ReceiverPhoneNumber { get; set; }
        
        public Mailbox MailBox { get; set; }
        
        public ShipmentSize ShipmentSize { get; set; }
    }
}