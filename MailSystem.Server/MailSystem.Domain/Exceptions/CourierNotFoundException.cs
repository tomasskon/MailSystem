using System;

namespace MailSystem.Domain.Exceptions
{
    public class CourierNotFoundException : Exception
    {
        public CourierNotFoundException()
            : base("Courier not found")
        {
        }

        public CourierNotFoundException(string message)
            : base(message)
        {
        }

        public CourierNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}