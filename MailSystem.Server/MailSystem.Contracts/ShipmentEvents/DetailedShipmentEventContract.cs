using System;
using MailSystem.Contracts.Enums;
using MailSystem.Contracts.Mailboxes;

namespace MailSystem.Contracts.ShipmentEvents
{
    public class DetailedShipmentEventContract
    {
        public Guid Id { get; set; }
        
        public Guid ShipmentId { get; set; }
        
        public MailboxContract Mailbox { get; set; }
        
        public DateTime EventDate { get; set; }
        
        public ShipmentStatus ShipmentStatus { get; set; }
    }
}