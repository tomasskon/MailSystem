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
    public class CourierRepository : ICourierRepository
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly IMapper _mapper;

        public CourierRepository(ISessionFactory sessionFactory, IMapper mapper)
        {
            _sessionFactory = sessionFactory;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Courier>> GetAll()
        {
            using var session = _sessionFactory.OpenSession();
            var courierEntities = await session.Query<CourierEntity>().ToListAsync();

            return _mapper.Map<List<Courier>>(courierEntities);
        }

        public async Task<Guid> Create(Courier courier)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            var courierEntity = _mapper.Map<CourierEntity>(courier);
            await session.SaveAsync(courierEntity);
            await transaction.CommitAsync();
            
            return courierEntity.Id;
        }

        public async Task<Courier> Get(Guid courierId)
        {
            using var session = _sessionFactory.OpenSession();

            var courierEntity = await session.GetAsync<CourierEntity>(courierId);

            return _mapper.Map<Courier>(courierEntity);
        }

        public async Task<Courier> GetByEmail(string email)
        {
            using var session = _sessionFactory.OpenSession();

            var courierEntity = await session.Query<CourierEntity>().SingleOrDefaultAsync(x => x.Email == email);

            return _mapper.Map<Courier>(courierEntity);
        }
        
        public async Task Update(Courier courier)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();
            
            var courierEntity = await session.GetAsync<CourierEntity>(courier.Id);
            courierEntity.FullName = courier.FullName;
            courierEntity.Phone = courier.Phone;
            courierEntity.Email = courier.Email;

            await session.UpdateAsync(courierEntity);
            await transaction.CommitAsync();
        }

        public async Task Delete(Guid courierId)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();
            
            var courierEntity = await session.GetAsync<CourierEntity>(courierId);
            courierEntity.Email = Guid.NewGuid().ToString();
            courierEntity.Phone = string.Empty;

            await session.DeleteAsync(courierEntity);
            await transaction.CommitAsync();
        }
        
        public async Task<bool> CheckIfEmailAlreadyUsed(string email)
        {
            using var session = _sessionFactory.OpenSession();

            return await session.Query<CourierEntity>().AnyAsync(x => x.Email == email);
        }
        
        public async Task<bool> CheckIfExists(Guid courierId)
        {
            using var session = _sessionFactory.OpenSession();

            return await session.Query<CourierEntity>().AnyAsync(x => x.Id == courierId);
        }
    }
}
