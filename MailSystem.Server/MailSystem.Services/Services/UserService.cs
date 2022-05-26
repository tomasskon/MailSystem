using System;
using System.Collections.Generic;
using MailSystem.Domain.Exceptions;
using MailSystem.Domain.Models;
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

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public Guid Create(User user)
        {
            if (_userRepository.CheckIfEmailAlreadyUsed(user.Email))
                throw new UserEmailAlreadyUsedException($"User email already used: {user.Email}");

            return _userRepository.Create(user);
        }

        public User Get(Guid userId)
        {
            var user = _userRepository.Get(userId);

            if (user is null)
                throw new UserNotFoundException($"User not found. User id: {userId}");

            return user;
        }

        public void Update(User user)
        {
            var existingUser = _userRepository.Get(user.Id);

            if (existingUser is null)
                throw new UserNotFoundException($"User not found. User id: {user.Id}");

            CheckEmailValidity(user, user.Email);

            _userRepository.Update(user);
        }

        public void Delete(Guid userId)
        {
            if (!_userRepository.CheckIfExists(userId))
                throw new UserNotFoundException($"User not found. User id: {userId}");

            _userRepository.Delete(userId);
        }

        private void CheckEmailValidity(User user, string email)
        {
            if (user.Email != email && !_userRepository.CheckIfEmailAlreadyUsed(email))
                throw new UserEmailAlreadyUsedException($"User email already used: {user.Email}");
        }

        public User GetByEmail(string email)
        {
            var user = _userRepository.GetByEmail(email);
            
            if(user is null)
                throw new UserNotFoundException($"User not found. User email: {email}");

            return user;
        }
    }
}