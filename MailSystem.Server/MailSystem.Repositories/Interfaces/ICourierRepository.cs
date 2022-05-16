using System;
using System.Collections.Generic;
using MailSystem.Domain.Models;

namespace MailSystem.Repositories.Interfaces
{
    public interface ICourierRepository
    {
        IEnumerable<Courier> GetAll();

        Guid Create(Courier courier);

        Courier Get(Guid courierId);

        void Delete(Guid courierId);

        bool CheckIfEmailAlreadyUsed(string email);

        bool CheckIfExists(Guid courierId);

        void Update(Courier courier);
    }
}