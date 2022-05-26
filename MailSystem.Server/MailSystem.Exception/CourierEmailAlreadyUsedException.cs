namespace MailSystem.Exception
{
    public class CourierEmailAlreadyUsedException : System.Exception
    {
        public CourierEmailAlreadyUsedException()
            : base("Courier not found")
        {
        }

        public CourierEmailAlreadyUsedException(string message)
            : base(message)
        {
        }

        public CourierEmailAlreadyUsedException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}