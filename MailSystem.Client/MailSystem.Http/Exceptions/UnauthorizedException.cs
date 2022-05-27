using System;

namespace MailSystem.Http.Exceptions
{
    public class UnauthorizedException : System.Exception
    {
        public UnauthorizedException() : 
            base(message: "You must login to access this page")
        {
        }

        public UnauthorizedException(string message)
        {
        }
    }
}