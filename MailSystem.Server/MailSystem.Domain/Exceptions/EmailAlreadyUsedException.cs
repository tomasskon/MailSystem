using System;

namespace MailSystem.Domain.Exceptions
{
    public class EmailAlreadyUsedException : Exception
    {
        public EmailAlreadyUsedException()
            : base("User not found")
        {
        }

        public EmailAlreadyUsedException(string message)
            : base(message)
        {
        }

        public EmailAlreadyUsedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}