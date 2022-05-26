namespace MailSystem.Exception
{
    public class NoShipmentEventsFoundException : System.Exception
    {
        public NoShipmentEventsFoundException()
            : base("No shipment events found")
        {
        }

        public NoShipmentEventsFoundException(string message)
            : base(message)
        {
        }

        public NoShipmentEventsFoundException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}