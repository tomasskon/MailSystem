using System;

namespace MailSystem.Domain.Exceptions
{
    public class MailboxNotFoundException : Exception
    {
        public MailboxNotFoundException()
            : base("Mailbox not found")
        {
        }

        public MailboxNotFoundException(string message)
            : base(message)
        {
        }

        public MailboxNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}