using System;

namespace MailSystem.Contracts.Couriers
{
    public class UpdateCourierContract
    {
        public Guid Id { get; set; }
        
        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}