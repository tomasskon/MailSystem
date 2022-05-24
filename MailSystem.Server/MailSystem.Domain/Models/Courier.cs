using System;

namespace MailSystem.Domain.Models
{
    public class Courier
    {
        public Guid Id { get; set; }
        
        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        
        public DateTime? DeletedAt { get; set; }
        
    }
}