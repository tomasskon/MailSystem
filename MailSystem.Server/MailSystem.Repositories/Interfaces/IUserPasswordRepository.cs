using System;
using MailSystem.Domain.Models;

namespace MailSystem.Repositories.Interfaces
{
    public interface IUserPasswordRepository
    {
        Guid Create(string passwordHash, byte[] passwordSalt, Guid userId);

        UserPassword GetByUserId(Guid userId);
    }
}