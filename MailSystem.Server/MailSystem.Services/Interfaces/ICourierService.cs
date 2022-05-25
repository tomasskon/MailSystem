using System;
using System.Collections.Generic;
using MailSystem.Domain.Models;

namespace MailSystem.Services.Interfaces
{
    public interface ICourierService
    {
        IEnumerable<Courier> GetAll();

        Guid Create(Courier courier);

        Courier Get(Guid courierId);

        void Update(Courier courier);

        void Delete(Guid guid);

        Courier GetByEmail(string email);
    }
}