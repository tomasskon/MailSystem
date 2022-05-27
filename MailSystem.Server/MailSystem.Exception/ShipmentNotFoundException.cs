namespace MailSystem.Exception
{
    public class ShipmentNotFoundException : System.Exception
    {
        public ShipmentNotFoundException()
            : base("Shipment not found")
        {
        }

        public ShipmentNotFoundException(string message)
            : base(message)
        {
        }

        public ShipmentNotFoundException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}