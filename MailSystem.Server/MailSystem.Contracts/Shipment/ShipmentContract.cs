using System;
using MailSystem.Contracts.Enums;
using MailSystem.Contracts.Mailboxes;
using MailSystem.Contracts.ShipmentSizes;

namespace MailSystem.Contracts.Shipment
{
    public class ShipmentContract
    {
        public Guid Id { get; set; }
        
        public string ReceiverFullName { get; set; }
        
        public MailboxContract Mailbox { get; set; }

        public ShipmentSizeContract ShipmentSize { get; set; }
        
        public ShipmentStatus ShipmentStatus { get; set; }
    }
}