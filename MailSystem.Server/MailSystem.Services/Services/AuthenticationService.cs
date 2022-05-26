using System;
using MailSystem.Domain.Enums;
using MailSystem.Domain.Models;
using MailSystem.Repositories.Interfaces;
using MailSystem.Services.Interfaces;

namespace MailSystem.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly ICourierService _courierService;
        private readonly IPasswordService _passwordService;
        private readonly ICourierPasswordRepository _courierPasswordRepository;
        private readonly IUserPasswordRepository _userPasswordRepository;

        public AuthenticationService(ITokenService tokenService, IUserService userService, IPasswordService passwordService, 
            ICourierPasswordRepository courierPasswordRepository, ICourierService courierService, IUserPasswordRepository userPasswordRepository)
        {
            _tokenService = tokenService;
            _userService = userService;
            _passwordService = passwordService;
            _courierPasswordRepository = courierPasswordRepository;
            _courierService = courierService;
            _userPasswordRepository = userPasswordRepository;
        }

        public string CourierLogin(string emailAddress, string password)
        {
            var courier = _courierService.GetByEmail(emailAddress);

            var courierPassword = _courierPasswordRepository.GetByUserId(courier.Id);
            _passwordService.ValidatePassword(password, courierPassword.PasswordHash, courierPassword.PasswordSalt);
            
            return _tokenService.GetJwtToken(courier.Id, UserType.Courier);
        }

        public string CourierRegister(Courier courier, string password)
        {
            var courierId = _courierService.Create(courier);

            var (passwordHash, passwordSalt) = _passwordService.CreateHashedPassword(password);
            _courierPasswordRepository.Create(passwordHash, passwordSalt, courierId);
            
            return _tokenService.GetJwtToken(courierId, UserType.Courier);
        }

        public string UserLogin(string emailAddress, string password)
        {
            var user = _userService.GetByEmail(emailAddress);

            var userPassword = _userPasswordRepository.GetByUserId(user.Id);
            _passwordService.ValidatePassword(password, userPassword.PasswordHash, userPassword.PasswordSalt);
            
            return _tokenService.GetJwtToken(user.Id, UserType.User);
        }

        public string UserRegister(User user, string password)
        {
            var userId = _userService.Create(user);

            var (passwordHash, passwordSalt) = _passwordService.CreateHashedPassword(password);
            _userPasswordRepository.Create(passwordHash, passwordSalt, userId);
            
            return _tokenService.GetJwtToken(userId, UserType.User);
        }
    }
}