using System;
using System.Threading.Tasks;
using MailSystem.Domain.Models;

namespace MailSystem.Repositories.Interfaces
{
    public interface ICourierPasswordRepository
    {
        Task<Guid> Create(string passwordHash, byte[] passwordSalt, Guid userId);

        Task<CourierPassword> GetByUserId(Guid courierId);
    }
}