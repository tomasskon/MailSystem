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
            return _userRepository.Create(user);
        }

        public User Get(Guid userId)
        {
            var user = _userRepository.Get(userId);

            if (user is null)
                throw new UserNotFoundException($"User not found. User id: {userId}");

            return user;
        }
    }
}