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
    public class CourierRepository : ICourierRepository
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly IMapper _mapper;

        public CourierRepository(ISessionFactory sessionFactory, IMapper mapper)
        {
            _sessionFactory = sessionFactory;
            _mapper = mapper;
        }

        public IEnumerable<Courier> GetAll()
        {
            using var session = _sessionFactory.OpenSession();
            var courierEntities = session.Query<CourierEntity>().ToList();

            return _mapper.Map<List<Courier>>(courierEntities);
        }

        public Guid Create(Courier courier)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();
            
            courier.CreatedAt = DateTime.UtcNow;
            courier.UpdatedAt = DateTime.UtcNow;
            
            var courierEntity = _mapper.Map<CourierEntity>(courier);
            session.Save(courierEntity);
            transaction.Commit();
            
            return courierEntity.Id;
        }

        public Courier Get(Guid courierId)
        {
            using var session = _sessionFactory.OpenSession();

            var courierEntity = session.Get<CourierEntity>(courierId);

            return _mapper.Map<Courier>(courierEntity);
        }
        
        public void Update(Courier courier)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();
            
            var courierEntity = session.Get<CourierEntity>(courier.Id);
            courierEntity.Username = courier.Username;
            courierEntity.FullName = courier.FullName;
            courierEntity.Phone = courier.Phone;
            courierEntity.Email = courier.Email;
            //courierEntity.UpdatedAt = DateTime.UtcNow;
            
            session.Update(courierEntity);
            transaction.Commit();
        }

        public void Delete(Guid courierId)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();
            
            var courierEntity = session.Get<CourierEntity>(courierId);
            courierEntity.Email = Guid.NewGuid().ToString();
            courierEntity.Phone = string.Empty;
            courierEntity.Username = string.Empty;
            courierEntity.UpdatedAt = DateTime.UtcNow;
            
            session.Delete(courierEntity);
            transaction.Commit();
        }
        
        public bool CheckIfEmailAlreadyUsed(string email)
        {
            using var session = _sessionFactory.OpenSession();

            return session.Query<CourierEntity>().Any(x => x.Email == email);
        }
        
        public bool CheckIfExists(Guid courierId)
        {
            using var session = _sessionFactory.OpenSession();

            return session.Query<CourierEntity>().Any(x => x.Id == courierId);
        }
    }
}