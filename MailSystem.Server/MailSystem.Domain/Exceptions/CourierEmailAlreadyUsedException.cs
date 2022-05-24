using System;

namespace MailSystem.Domain.Exceptions
{
    public class CourierEmailAlreadyUsedException : Exception
    {
        public CourierEmailAlreadyUsedException()
            : base("Courier not found")
        {
        }

        public CourierEmailAlreadyUsedException(string message)
            : base(message)
        {
        }

        public CourierEmailAlreadyUsedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}