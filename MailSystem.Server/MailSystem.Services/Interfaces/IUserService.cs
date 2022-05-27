using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Domain.Models;

namespace MailSystem.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();

        Task<Guid> Create(User user);

        Task<User> Get(Guid userId);
        
        Task Update(User user);
        
        Task Delete(Guid userId);

        Task<User> GetByEmail(string email);

        Task CheckIfUserExists(Guid userId);
    }
}