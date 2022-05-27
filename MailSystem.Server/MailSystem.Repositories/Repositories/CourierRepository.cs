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
    public class CourierRepository : ICourierRepository
    {
        private readonly ISession _session;
        private readonly IMapper _mapper;

        public CourierRepository(ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Courier>> GetAll()
        {
            var courierEntities = await _session.Query<CourierEntity>().ToListAsync();

            return _mapper.Map<List<Courier>>(courierEntities);
        }

        public async Task<Guid> Create(Courier courier)
        {
            using var transaction = _session.BeginTransaction();

            var courierEntity = _mapper.Map<CourierEntity>(courier);
            await _session.SaveAsync(courierEntity);
            await transaction.CommitAsync();
            
            return courierEntity.Id;
        }

        public async Task<Courier> Get(Guid courierId)
        {
            var courierEntity = await _session.GetAsync<CourierEntity>(courierId);

            return _mapper.Map<Courier>(courierEntity);
        }

        public async Task<Courier> GetByEmail(string email)
        {
            var courierEntity = await _session.Query<CourierEntity>().SingleOrDefaultAsync(x => x.Email == email);

            return _mapper.Map<Courier>(courierEntity);
        }
        
        public async Task Update(Courier courier)
        {
            using var transaction = _session.BeginTransaction();
            
            var courierEntity = await _session.GetAsync<CourierEntity>(courier.Id);
            courierEntity.FullName = courier.FullName;
            courierEntity.Phone = courier.Phone;
            courierEntity.Email = courier.Email;

            await _session.UpdateAsync(courierEntity);
            await transaction.CommitAsync();
        }

        public async Task Delete(Guid courierId)
        {
            using var transaction = _session.BeginTransaction();
            
            var courierEntity = await _session.GetAsync<CourierEntity>(courierId);
            courierEntity.Email = Guid.NewGuid().ToString();
            courierEntity.Phone = string.Empty;

            await _session.DeleteAsync(courierEntity);
            await transaction.CommitAsync();
        }
        
        public async Task<bool> CheckIfEmailAlreadyUsed(string email)
        {
            return await _session.Query<CourierEntity>().AnyAsync(x => x.Email == email);
        }
        
        public async Task<bool> CheckIfExists(Guid courierId)
        {
            return await _session.Query<CourierEntity>().AnyAsync(x => x.Id == courierId);
        }
    }
}
