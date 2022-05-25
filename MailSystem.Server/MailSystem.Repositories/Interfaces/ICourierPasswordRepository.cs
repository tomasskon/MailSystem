using System;
using MailSystem.Domain.Models;

namespace MailSystem.Repositories.Interfaces
{
    public interface ICourierPasswordRepository
    {
        Guid Create(string passwordHash, byte[] passwordSalt, Guid userId);

        CourierPassword GetByUserId(Guid courierId);
    }
}