namespace MailSystem.Exception
{
    public class ShipmentSizeNotFoundException : System.Exception
    {
        public ShipmentSizeNotFoundException()
            : base("Shipment size not found")
        {
        }

        public ShipmentSizeNotFoundException(string message)
            : base(message)
        {
        }

        public ShipmentSizeNotFoundException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}