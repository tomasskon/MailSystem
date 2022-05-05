using System;

namespace MailSystem.Domain.Models
{
    public class User
    {
        public string Email { get; set; }
        
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
    }
}