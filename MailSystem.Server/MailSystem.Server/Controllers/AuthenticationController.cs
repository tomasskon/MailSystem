using System.Threading.Tasks;
using AutoMapper;
using MailSystem.Contracts;
using MailSystem.Contracts.Authentication;
using MailSystem.Domain.Models;
using MailSystem.Exception;
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
        
        /// <response code="404">CourierNotFoundException</response>
        /// <response code="400">InvalidPasswordException</response>
        [HttpPost]
        public async Task<IActionResult> CourierLogin([FromBody] CourierLoginContract courierLoginContract)
        {
            try
            {
                return Ok(await _authenticationService.CourierLogin(courierLoginContract.EmailAddress,
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
        
        /// <response code="400">CourierEmailAlreadyUsedException</response>
        [HttpPost]
        public async Task<IActionResult> CourierRegister([FromBody] CourierRegisterContract courierRegisterContract)
        {
            try
            {
                var courier = _mapper.Map<Courier>(courierRegisterContract);
            
                return Ok(await _authenticationService.CourierRegister(courier, courierRegisterContract.Password));
            }
            catch (CourierEmailAlreadyUsedException ex)
            {
                return BadRequest(new StandardExceptionResponse(ex));
            }
        }
        
        /// <response code="404">UserNotFoundException</response>
        /// <response code="400">InvalidPasswordException</response>
        [HttpPost]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginContract userLoginContract)
        {
            try
            {
                return Ok(await _authenticationService.UserLogin(userLoginContract.EmailAddress,
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
        
        /// <response code="400">UserEmailAlreadyUsedException</response>
        [HttpPost]
        public async Task<IActionResult> UserRegister([FromBody] UserRegisterContract userRegisterContract)
        {
            try
            {
                var user = _mapper.Map<User>(userRegisterContract);
            
                return Ok(await _authenticationService.UserRegister(user, userRegisterContract.Password));
            }
            catch (UserEmailAlreadyUsedException ex)
            {
                return BadRequest(new StandardExceptionResponse(ex));
            }
        }
    }
}