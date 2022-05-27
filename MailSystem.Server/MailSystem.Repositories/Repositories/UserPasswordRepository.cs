using System;
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
    public class UserPasswordRepository : IUserPasswordRepository
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly IMapper _mapper;

        public UserPasswordRepository(ISessionFactory sessionFactory, IMapper mapper)
        {
            _sessionFactory = sessionFactory;
            _mapper = mapper;
        }

        public async Task<Guid> Create(string passwordHash, byte[] passwordSalt, Guid userId)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();
            
            var userPasswordEntity = new UserPasswordEntity
            {
                User = new UserEntity{ Id = userId },
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
            
            await session.SaveAsync(userPasswordEntity);
            await transaction.CommitAsync();

            return userPasswordEntity.Id;
        }

        public async Task<UserPassword> GetByUserId(Guid userId)
        {
            using var session = _sessionFactory.OpenSession();

            var passwordEntity = await session.Query<UserPasswordEntity>().SingleOrDefaultAsync(x => x.User.Id == userId);

            return _mapper.Map<UserPassword>(passwordEntity);
        }
    }
}