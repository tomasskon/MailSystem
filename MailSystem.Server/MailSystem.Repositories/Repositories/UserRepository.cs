using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MailSystem.Domain.Models;
using MailSystem.Repositories.Entities;
using MailSystem.Repositories.Interfaces;
using NHibernate;

namespace MailSystem.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly IMapper _mapper;

        public UserRepository(ISessionFactory sessionFactory, IMapper mapper)
        {
            _sessionFactory = sessionFactory;
            _mapper = mapper;
        }

        public IEnumerable<User> GetAll()
        {
            using var session = _sessionFactory.OpenSession();
            var userEntities = session.Query<UserEntity>().ToList();

            return _mapper.Map<List<User>>(userEntities);
        }

        public Guid Create(User user)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            var userEntity = _mapper.Map<UserEntity>(user);
            session.Save(userEntity);

            return userEntity.Id;
        }

        public User Get(Guid userId)
        {
            using var session = _sessionFactory.OpenSession();

            var userEntity = session.Get<UserEntity>(userId);

            return _mapper.Map<User>(userEntity);
        }
    }
}