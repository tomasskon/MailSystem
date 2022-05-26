using System;

namespace MailSystem.Domain.Exceptions
{
    public class ShipmentSizeNotFoundException : Exception
    {
        public ShipmentSizeNotFoundException()
            : base("Shipment size not found")
        {
        }

        public ShipmentSizeNotFoundException(string message)
            : base(message)
        {
        }

        public ShipmentSizeNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}