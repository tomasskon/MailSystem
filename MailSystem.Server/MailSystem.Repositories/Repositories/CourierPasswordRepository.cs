using System;
using System.Linq;
using AutoMapper;
using MailSystem.Domain.Models;
using MailSystem.Repositories.Entities;
using MailSystem.Repositories.Interfaces;
using NHibernate;

namespace MailSystem.Repositories.Repositories
{
    public class CourierPasswordRepository : ICourierPasswordRepository
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly IMapper _mapper;

        public CourierPasswordRepository(ISessionFactory sessionFactory, IMapper mapper)
        {
            _sessionFactory = sessionFactory;
            _mapper = mapper;
        }

        public Guid Create(string passwordHash, byte[] passwordSalt, Guid userId)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();
            
            var userPasswordEntity = new CourierPasswordEntity
            {
                Courier = new CourierEntity{ Id = userId },
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
            
            session.Save(userPasswordEntity);
            transaction.Commit();

            return userPasswordEntity.Id;
        }

        public CourierPassword GetByUserId(Guid courierId)
        {
            using var session = _sessionFactory.OpenSession();

            var passwordEntity = session.Query<CourierPasswordEntity>().SingleOrDefault(x => x.Courier.Id == courierId);

            return _mapper.Map<CourierPassword>(passwordEntity);
        }
    }
}