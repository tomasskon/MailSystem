using System;

namespace MailSystem.Contracts.Users
{
    public class UserContract
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool IsDisabled { get; set; }
    }
}