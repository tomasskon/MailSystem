using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Contracts.Mailboxes;

namespace MailSystem.Http.Interfaces
{
    public interface IMailboxHttpClient
    {
        Task<IEnumerable<MailboxContract>> GetMailboxes();
    }
}