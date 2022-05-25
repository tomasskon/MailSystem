using AutoMapper;
using MailSystem.Contracts;
using MailSystem.Contracts.Authentication;
using MailSystem.Domain.Exceptions;
using MailSystem.Domain.Models;
using MailSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MailSystem.Server.Controllers
{
    [Route("[controller]/[action]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public AuthenticationController(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CourierLogin([FromBody] CourierLoginContract courierLoginContract)
        {
            try
            {
                return Ok(_authenticationService.CourierLogin(courierLoginContract.EmailAddress,
                    courierLoginContract.Password));
            }
            catch (CourierNotFoundException ex)
            {
                return NotFound(new StandardExceptionResponse(ex));
            }
            catch (InvalidPasswordException ex)
            {
                return BadRequest(new StandardExceptionResponse(ex)); 
            }
        }

        [HttpPost]
        public IActionResult CourierRegister([FromBody] CourierRegisterContract courierRegisterContract)
        {
            try
            {
                var courier = _mapper.Map<Courier>(courierRegisterContract);
            
                return Ok(_authenticationService.CourierRegister(courier, courierRegisterContract.Password));
            }
            catch (CourierEmailAlreadyUsedException ex)
            {
                return BadRequest(new StandardExceptionResponse(ex));
            }
        }
        
        [HttpPost]
        public IActionResult UserLogin([FromBody] UserLoginContract userLoginContract)
        {
            try
            {
                return Ok(_authenticationService.UserLogin(userLoginContract.EmailAddress,
                    userLoginContract.Password));
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new StandardExceptionResponse(ex));
            }
            catch (InvalidPasswordException ex)
            {
                return BadRequest(new StandardExceptionResponse(ex)); 
            }
        }

        [HttpPost]
        public IActionResult UserRegister([FromBody] UserRegisterContract userRegisterContract)
        {
            try
            {
                var user = _mapper.Map<User>(userRegisterContract);
            
                return Ok(_authenticationService.UserRegister(user, userRegisterContract.Password));
            }
            catch (UserEmailAlreadyUsedException ex)
            {
                return BadRequest(new StandardExceptionResponse(ex));
            }
        }
    }
}