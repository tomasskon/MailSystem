using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MailSystem.Domain.Models;
using MailSystem.Repositories.Entities;
using MailSystem.Repositories.Interfaces;
using NHibernate;
using NHibernate.Linq;

namespace MailSystem.Repositories.Repositories
{
    public class MailboxRepository : IMailboxRepository
    {
        private readonly ISession _session;
        private readonly IMapper _mapper;

        public MailboxRepository(ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Mailbox>> GetAll()
        {
            var mailboxEntities = await _session.Query<MailboxEntity>().ToListAsync();

            return _mapper.Map<List<Mailbox>>(mailboxEntities);
        }

        public async Task<bool> CheckIfExists(Guid mailboxId)
        {
            return await _session.Query<MailboxEntity>().AnyAsync(x => x.Id == mailboxId);
        }
    }
}