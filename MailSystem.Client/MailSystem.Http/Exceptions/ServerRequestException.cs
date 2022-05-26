using System;

namespace MailSystem.Http.Exceptions
{
    public class ServerRequestException : Exception
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
        
        public ServerRequestException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}