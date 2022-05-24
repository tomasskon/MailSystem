using System;

namespace MailSystem.Services.Interfaces
{
    public interface IPasswordService
    {
        void ValidatePassword(string password, string passwordHash, byte[] passwordSalt);

        Tuple<string, byte[]> CreateHashedPassword(string password, byte[] storedSalt = null);
    }
}