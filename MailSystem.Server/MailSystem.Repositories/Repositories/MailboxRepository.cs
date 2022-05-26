using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MailSystem.Domain.Models;
using MailSystem.Repositories.Entities;
using MailSystem.Repositories.Interfaces;
using NHibernate;

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

        public IEnumerable<Mailbox> GetAll()
        {
            using var session = _sessionFactory.OpenSession();
            var mailboxEntities = session.Query<MailboxEntity>().ToList();

            return _mapper.Map<List<Mailbox>>(mailboxEntities);
        }
    }
}