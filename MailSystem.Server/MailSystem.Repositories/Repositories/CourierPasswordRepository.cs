using System;
using System.Threading.Tasks;
using AutoMapper;
using MailSystem.Domain.Models;
using MailSystem.Repositories.Entities;
using MailSystem.Repositories.Interfaces;
using NHibernate;
using NHibernate.Linq;

namespace MailSystem.Repositories.Repositories
{
    public class CourierPasswordRepository : ICourierPasswordRepository
    {
        private readonly ISession _session;
        private readonly IMapper _mapper;

        public CourierPasswordRepository(ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        public async Task<Guid> Create(string passwordHash, byte[] passwordSalt, Guid userId)
        {
            using var transaction = _session.BeginTransaction();
            
            var userPasswordEntity = new CourierPasswordEntity
            {
                Courier = new CourierEntity{ Id = userId },
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
            
            await _session.SaveAsync(userPasswordEntity);
            await transaction.CommitAsync();

            return userPasswordEntity.Id;
        }

        public async Task<CourierPassword> GetByUserId(Guid courierId)
        {
            var passwordEntity = await _session.Query<CourierPasswordEntity>().SingleOrDefaultAsync(x => x.Courier.Id == courierId);

            return _mapper.Map<CourierPassword>(passwordEntity);
        }
    }
}