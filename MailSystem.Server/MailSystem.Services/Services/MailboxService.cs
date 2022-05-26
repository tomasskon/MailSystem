using System;
using System.Collections.Generic;
using MailSystem.Domain.Exceptions;
using MailSystem.Domain.Models;
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

        public IEnumerable<Mailbox> GetAll()
        {
            return _mailboxRepository.GetAll();
        }

        public void CheckIfMailboxExists(Guid mailboxId)
        {
            if (!_mailboxRepository.CheckIfExists(mailboxId))
                throw new MailboxNotFoundException($"Mailbox not found. Mailbox id: {mailboxId}");
        }
    }
}