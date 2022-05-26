using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Domain.Models;

namespace MailSystem.Services.Interfaces
{
    public interface ICourierService
    {
        Task<IEnumerable<Courier>> GetAll();

        Task<Guid> Create(Courier courier);

        Task<Courier> Get(Guid courierId);

        Task Update(Courier courier);

        Task Delete(Guid guid);

        Task<Courier> GetByEmail(string email);
    }
}