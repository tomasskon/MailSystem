using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Domain.Models;

namespace MailSystem.Services.Interfaces
{
    public interface IMailboxService
    {
        Task<IEnumerable<Mailbox>> GetAll();

        Task CheckIfMailboxExists(Guid mailboxId);
    }
}