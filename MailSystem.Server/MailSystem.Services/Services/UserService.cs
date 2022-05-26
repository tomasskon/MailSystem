using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Domain.Models;
using MailSystem.Exception;
using MailSystem.Repositories.Interfaces;
using MailSystem.Services.Interfaces;

namespace MailSystem.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<Guid> Create(User user)
        {
            if (await _userRepository.CheckIfEmailAlreadyUsed(user.Email))
                throw new UserEmailAlreadyUsedException($"User email already used: {user.Email}");

            return await _userRepository.Create(user);
        }

        public async Task<User> Get(Guid userId)
        {
            var user = await _userRepository.Get(userId);

            if (user is null)
                throw new UserNotFoundException($"User not found. User id: {userId}");

            return user;
        }

        public async Task Update(User user)
        {
            var existingUser = await _userRepository.Get(user.Id);

            if (existingUser is null)
                throw new UserNotFoundException($"User not found. User id: {user.Id}");

            await CheckEmailValidity(existingUser, user.Email);

            await _userRepository.Update(user);
        }

        public async Task Delete(Guid userId)
        {
            if (!await _userRepository.CheckIfExists(userId))
                throw new UserNotFoundException($"User not found. User id: {userId}");

            await _userRepository.Delete(userId);
        }

        private async Task CheckEmailValidity(User existingUser, string emailToChange)
        {
            if (existingUser.Email != emailToChange && await _userRepository.CheckIfEmailAlreadyUsed(emailToChange))
                throw new UserEmailAlreadyUsedException($"User email already used: {existingUser.Email}");
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            
            if(user is null)
                throw new UserNotFoundException($"User not found. User email: {email}");

            return user;
        }

        public async Task CheckIfUserExists(Guid userId)
        {
            if (!await _userRepository.CheckIfExists(userId))
                throw new UserNotFoundException($"User not found: {userId}");
        }
    }
}