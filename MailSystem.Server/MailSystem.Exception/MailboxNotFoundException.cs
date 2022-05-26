namespace MailSystem.Exception
{
    public class MailboxNotFoundException : System.Exception
    {
        public MailboxNotFoundException()
            : base("Mailbox not found")
        {
        }

        public MailboxNotFoundException(string message)
            : base(message)
        {
        }

        public MailboxNotFoundException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}