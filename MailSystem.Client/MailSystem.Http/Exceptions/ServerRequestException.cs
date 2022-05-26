using System;

namespace MailSystem.Http.Exceptions
{
    public class ServerRequestException : System.Exception
    {
        public string ServerExceptionName { get; set; }
        public string ServerExceptionMessage { get; set; }

        public ServerRequestException(string serverExceptionName, string serverExceptionMessage)
            : base("Server error")
        {
            ServerExceptionName = serverExceptionName;
            ServerExceptionMessage = serverExceptionMessage;
        }

        public ServerRequestException(string message)
            : base(message)
        {
        }
        
        public ServerRequestException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}