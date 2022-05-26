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
    public class UserRepository : IUserRepository
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly IMapper _mapper;

        public UserRepository(ISessionFactory sessionFactory, IMapper mapper)
        {
            _sessionFactory = sessionFactory;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using var session = _sessionFactory.OpenSession();
            var userEntities = await session.Query<UserEntity>().ToListAsync();

            return _mapper.Map<List<User>>(userEntities);
        }

        public async Task<Guid> Create(User user)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            var userEntity = _mapper.Map<UserEntity>(user);
            await session.SaveAsync(userEntity);
            await transaction.CommitAsync();

            return userEntity.Id;
        }

        public async Task<User> Get(Guid userId)
        {
            using var session = _sessionFactory.OpenSession();

            var userEntity = await session.GetAsync<UserEntity>(userId);

            return _mapper.Map<User>(userEntity);
        }

        public async Task Update(User user)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            var userEntity = _mapper.Map<UserEntity>(user);
            userEntity.FullName = user.FullName;
            userEntity.Phone = user.Phone;
            userEntity.Email = user.Email;

            await session.UpdateAsync(userEntity);
            await transaction.CommitAsync();
        }

        public async Task Delete(Guid userId)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            var userEntity = session.Get<UserEntity>(userId);
            userEntity.Email = Guid.NewGuid().ToString();
            userEntity.Phone = string.Empty;

            await session.DeleteAsync(userEntity);
            await transaction.CommitAsync();
        }

        public async Task<bool> CheckIfEmailAlreadyUsed(string email)
        {
            using var session = _sessionFactory.OpenSession();

            return await session.Query<UserEntity>().AnyAsync(x => x.Email == email);
        }

        public async Task<bool> CheckIfExists(Guid userId)
        {
            using var session = _sessionFactory.OpenSession();

            return await session.Query<UserEntity>().AnyAsync(x => x.Id == userId);
        }
        
        public async Task<User> GetByEmail(string email)
        {
            using var session = _sessionFactory.OpenSession();

            var userEntity = await session.Query<UserEntity>().SingleOrDefaultAsync(x => x.Email == email);

            return _mapper.Map<User>(userEntity);
        }
    }
}
