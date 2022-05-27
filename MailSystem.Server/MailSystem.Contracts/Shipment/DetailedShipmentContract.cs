using System;
using System.Collections.Generic;
using MailSystem.Contracts.Enums;
using MailSystem.Contracts.Mailboxes;
using MailSystem.Contracts.ShipmentEvents;
using MailSystem.Contracts.ShipmentSizes;

namespace MailSystem.Contracts.Shipment
{
    public class DetailedShipmentContract
    {
        public Guid Id { get; set; }

        public string TrackingId { get; set; }
        
        public string Description { get; set; }

        public string ReceiverFullName { get; set; }
        
        public string ReceiverPhoneNumber { get; set; }
        
        public string ReceiverEmail { get; set; }
        
        public MailboxContract Mailbox { get; set; }
        
        public ShipmentSizeContract ShipmentStatus { get; set; }
    }
}