using System;

namespace MailSystem.Contracts
{
    public class StandardExceptionResponse
    {
        public StandardExceptionResponse()
        {
        }
        
        public StandardExceptionResponse(Exception exception)
        {
            Exception = exception.GetType().Name;
            Message = exception.Message;
        }

        public string Exception { get; set; }
        
        public string Message { get; set; }
    }
}