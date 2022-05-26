namespace MailSystem.Exception
{
    public class CourierNotFoundException : System.Exception
    {
        public CourierNotFoundException()
            : base("Courier not found")
        {
        }

        public CourierNotFoundException(string message)
            : base(message)
        {
        }

        public CourierNotFoundException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}