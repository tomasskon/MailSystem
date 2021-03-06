using System;
using MailSystem.Domain.Enums;

namespace MailSystem.Domain.Models
{
    public class ShipmentEvent
    {
        public Guid Id { get; set; }

        public Guid ShipmentId { get; set; }
        public Guid? MailboxId { get; set; }
        
        public DateTime EventDate { get; set; }
        
        public ShipmentStatus ShipmentStatus { get; set; }
    }
}