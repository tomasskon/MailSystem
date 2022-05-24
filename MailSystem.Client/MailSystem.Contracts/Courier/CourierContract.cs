using System;

namespace MailSystem.Contracts.Courier
{
    public class CourierContract
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}