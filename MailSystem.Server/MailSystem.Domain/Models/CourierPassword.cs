using System;

namespace MailSystem.Domain.Models
{
    public class CourierPassword
    {
        public Guid CourierId { get; set; }
        
        public string PasswordHash { get; set; }
        
        public byte[] PasswordSalt { get; set; }
    }
}