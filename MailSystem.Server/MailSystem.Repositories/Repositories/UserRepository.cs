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
    public class UserRepository : IUserRepository
    {
        private readonly ISession _session;
        private readonly IMapper _mapper;

        public UserRepository(ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var userEntities = await _session.Query<UserEntity>().ToListAsync();

            return _mapper.Map<List<User>>(userEntities);
        }

        public async Task<Guid> Create(User user)
        {
            using var transaction = _session.BeginTransaction();

            var userEntity = _mapper.Map<UserEntity>(user);
            await _session.SaveAsync(userEntity);
            await transaction.CommitAsync();

            return userEntity.Id;
        }

        public async Task<User> Get(Guid userId)
        {
            var userEntity = await _session.GetAsync<UserEntity>(userId);

            return _mapper.Map<User>(userEntity);
        }

        public async Task Update(User user)
        {
            using var transaction = _session.BeginTransaction();

            var userEntity = _mapper.Map<UserEntity>(user);
            userEntity.FullName = user.FullName;
            userEntity.Phone = user.Phone;
            userEntity.Email = user.Email;

            await _session.UpdateAsync(userEntity);
            await transaction.CommitAsync();
        }

        public async Task Delete(Guid userId)
        {
            using var transaction = _session.BeginTransaction();

            var userEntity = _session.Get<UserEntity>(userId);
            userEntity.Email = Guid.NewGuid().ToString();
            userEntity.Phone = string.Empty;

            await _session.DeleteAsync(userEntity);
            await transaction.CommitAsync();
        }

        public async Task<bool> CheckIfEmailAlreadyUsed(string email)
        {
            return await _session.Query<UserEntity>().AnyAsync(x => x.Email == email);
        }

        public async Task<bool> CheckIfExists(Guid userId)
        {
            return await _session.Query<UserEntity>().AnyAsync(x => x.Id == userId);
        }
        
        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _session.Query<UserEntity>().SingleOrDefaultAsync(x => x.Email == email);

            return _mapper.Map<User>(userEntity);
        }
    }
}
