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
    public class UserPasswordRepository : IUserPasswordRepository
    {
        private readonly ISession _session;
        private readonly IMapper _mapper;

        public UserPasswordRepository(ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        public async Task<Guid> Create(string passwordHash, byte[] passwordSalt, Guid userId)
        {
            using var transaction = _session.BeginTransaction();
            
            var userPasswordEntity = new UserPasswordEntity
            {
                User = new UserEntity{ Id = userId },
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
            
            await _session.SaveAsync(userPasswordEntity);
            await transaction.CommitAsync();

            return userPasswordEntity.Id;
        }

        public async Task<UserPassword> GetByUserId(Guid userId)
        {
            var passwordEntity = await _session.Query<UserPasswordEntity>().SingleOrDefaultAsync(x => x.User.Id == userId);

            return _mapper.Map<UserPassword>(passwordEntity);
        }
    }
}