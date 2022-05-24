using System;
using System.Collections.Generic;
using MailSystem.Domain.Models;

namespace MailSystem.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();

        Guid Create(User user);

        User Get(Guid userId);
        
        void Update(User user);
        
        void Delete(Guid userId);

        User GetByEmail(string email);
    }
}