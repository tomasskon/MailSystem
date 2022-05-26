using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Domain.Models;

namespace MailSystem.Repositories.Interfaces
{
    public interface IMailboxRepository
    {
        Task<IEnumerable<Mailbox>> GetAll();

        Task<bool> CheckIfExists(Guid mailboxId);
    }
}