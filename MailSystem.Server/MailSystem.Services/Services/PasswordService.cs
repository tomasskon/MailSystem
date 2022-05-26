using System;
using System.Security.Cryptography;
using MailSystem.Exception;
using MailSystem.Services.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace MailSystem.Services.Services
{
    public class PasswordService : IPasswordService
    {
        public Tuple<string, byte[]> CreateHashedPassword(string password, byte[] storedSalt = null)
        {
            var salt = storedSalt??new byte[128 / 8];

            if (storedSalt is null)
            {
                using var rngCsp = new RNGCryptoServiceProvider();
                rngCsp.GetNonZeroBytes(salt);    
            }
            
            return new Tuple<string, byte[]>
            (
                Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password,
                    salt,
                    KeyDerivationPrf.HMACSHA256,
                    100000,
                    256 / 8)),
                salt
            );
        }
        
        public void ValidatePassword(string password, string passwordHash, byte[] passwordSalt)
        {
            var (hashedPassword, _) = CreateHashedPassword(password, passwordSalt);

            if (hashedPassword != passwordHash)
                throw new InvalidPasswordException();
        }
    }
}