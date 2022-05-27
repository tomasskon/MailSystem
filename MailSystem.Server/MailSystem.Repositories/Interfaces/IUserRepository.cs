using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Domain.Models;

namespace MailSystem.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();

        Task<Guid> Create(User user);

        Task<User> Get(Guid userId);

        Task Update(User user);

        Task<bool> CheckIfEmailAlreadyUsed(string email);

        Task<bool> CheckIfExists(Guid userId);

        Task Delete(Guid userId);

        Task<User> GetByEmail(string email);
    }
}