using System;
using MailSystem.Domain.Enums;

namespace MailSystem.Domain.Models
{
    public class DetailedShipmentEvent
    {
        public Guid Id { get; set; }
        
        public Mailbox Mailbox { get; set; }
        
        public DateTime EventDate { get; set; }
        
        public ShipmentStatus ShipmentStatus { get; set; }
    }
}