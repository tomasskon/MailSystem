using System;
using System.Collections.Generic;
using MailSystem.Domain.Models;

namespace MailSystem.Repositories.Interfaces
{
    public interface IMailboxRepository
    {
        IEnumerable<Mailbox> GetAll();

        bool CheckIfExists(Guid mailboxId);
    }
}