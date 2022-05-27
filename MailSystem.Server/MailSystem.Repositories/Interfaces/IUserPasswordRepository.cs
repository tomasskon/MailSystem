using System;
using System.Threading.Tasks;
using MailSystem.Domain.Models;

namespace MailSystem.Repositories.Interfaces
{
    public interface IUserPasswordRepository
    {
        Task<Guid> Create(string passwordHash, byte[] passwordSalt, Guid userId);

        Task<UserPassword> GetByUserId(Guid userId);
    }
}