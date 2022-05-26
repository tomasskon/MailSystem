namespace MailSystem.Exception
{
    public class UserNotFoundException : System.Exception
    {
        public UserNotFoundException()
            : base("User not found")
        {
        }

        public UserNotFoundException(string message)
            : base(message)
        {
        }

        public UserNotFoundException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}