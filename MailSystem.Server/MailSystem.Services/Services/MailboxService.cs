using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Domain.Models;
using MailSystem.Exception;
using MailSystem.Repositories.Interfaces;
using MailSystem.Services.Interfaces;
using Remotion.Linq.Parsing;

namespace MailSystem.Services.Services
{
    public class MailboxService : IMailboxService
    {
        private readonly IMailboxRepository _mailboxRepository;

        public MailboxService(IMailboxRepository mailboxRepository)
        {
            _mailboxRepository = mailboxRepository;
        }

        public async Task<IEnumerable<Mailbox>> GetAll()
        {
            return await _mailboxRepository.GetAll();
        }

        public async Task CheckIfMailboxExists(Guid mailboxId)
        {
            if (!await _mailboxRepository.CheckIfExists(mailboxId))
                throw new MailboxNotFoundException($"Mailbox not found. Mailbox id: {mailboxId}");
        }
    }
}