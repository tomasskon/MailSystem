using System;
using MailSystem.Contracts.Enums;

namespace MailSystem.Contracts.ShipmentEvents
{
    public class UpdateShipmentStatusContract
    {
        public string TrackingId { get; set; }
        
        public ShipmentStatus ShipmentStatus { get; set; }
        
        public Guid? MailboxId { get; set; }
    }
}