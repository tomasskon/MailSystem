using System.Collections.Generic;
using MailSystem.Domain.Models;
using MailSystem.Repositories.Interfaces;
using MailSystem.Services.Interfaces;

namespace MailSystem.Services.Services
{
    public class MailboxService : IMailboxService
    {
        private readonly IMailboxRepository _mailboxRepository;

        public MailboxService(IMailboxRepository mailboxRepository)
        {
            _mailboxRepository = mailboxRepository;
        }

        public IEnumerable<Mailbox> GetAll()
        {
            return _mailboxRepository.GetAll();
        }
    }
}