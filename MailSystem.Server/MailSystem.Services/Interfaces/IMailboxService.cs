using System.Collections.Generic;
using MailSystem.Domain.Models;

namespace MailSystem.Services.Interfaces
{
    public interface IMailboxService
    {
        IEnumerable<Mailbox> GetAll();
    }
}