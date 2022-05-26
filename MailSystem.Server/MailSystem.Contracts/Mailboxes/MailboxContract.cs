using System;

namespace MailSystem.Contracts.Mailboxes
{
    public class MailboxContract
    {
        public Guid Id { get; set; }

        public string Location { get; set; }
    }
}