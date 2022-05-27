namespace MailSystem.Exception
{
    public class NoShipmentsFoundException : System.Exception
    {
        
        public NoShipmentsFoundException()
            : base("No shipments found")
        {
        }

        public NoShipmentsFoundException(string message)
            : base(message)
        {
        }

        public NoShipmentsFoundException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}