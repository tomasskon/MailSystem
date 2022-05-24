using System;

namespace MailSystem.Domain.Exceptions
{
    public class UserEmailAlreadyUsedException : Exception
    {
        public UserEmailAlreadyUsedException()
            : base("User not found")
        {
        }

        public UserEmailAlreadyUsedException(string message)
            : base(message)
        {
        }

        public UserEmailAlreadyUsedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}