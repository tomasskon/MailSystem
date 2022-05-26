using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ISessionFactory _sessionFactory;
        private readonly IMapper _mapper;

        public MailboxRepository(ISessionFactory sessionFactory, IMapper mapper)
        {
            _sessionFactory = sessionFactory;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Mailbox>> GetAll()
        {
            using var session = _sessionFactory.OpenSession();
            var mailboxEntities = await session.Query<MailboxEntity>().ToListAsync();

            return _mapper.Map<List<Mailbox>>(mailboxEntities);
        }

        public async Task<bool> CheckIfExists(Guid mailboxId)
        {
            using var session = _sessionFactory.OpenSession();

            return await session.Query<MailboxEntity>().AnyAsync(x => x.Id == mailboxId);
        }
    }
}