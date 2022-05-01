using System;

namespace MailSystem.Contracts.User
{
    public class UserContract
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
    }
}