using System;

namespace MailSystem.Domain.Exceptions
{
    public class NoShipmentEventsFoundException : Exception
    {
        public NoShipmentEventsFoundException()
            : base("No shipment events found")
        {
        }

        public NoShipmentEventsFoundException(string message)
            : base(message)
        {
        }

        public NoShipmentEventsFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}