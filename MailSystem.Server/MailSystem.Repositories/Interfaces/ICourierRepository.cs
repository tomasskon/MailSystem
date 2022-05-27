using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Domain.Models;

namespace MailSystem.Repositories.Interfaces
{
    public interface ICourierRepository
    {
        Task<IEnumerable<Courier>> GetAll();

        Task<Guid> Create(Courier courier);

        Task<Courier> Get(Guid courierId);

        Task Delete(Guid courierId);

        Task<bool> CheckIfEmailAlreadyUsed(string email);

        Task<bool> CheckIfExists(Guid courierId);

        Task Update(Courier courier);

        Task<Courier> GetByEmail(string email);
    }
}