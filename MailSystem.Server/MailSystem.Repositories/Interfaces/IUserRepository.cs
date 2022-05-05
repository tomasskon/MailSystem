using System;
using System.Collections.Generic;
using MailSystem.Domain.Models;

namespace MailSystem.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        Guid Create(User user);

        User Get(Guid userId);

        bool CheckIfEmailAlreadyUsed(string email);
    }
}