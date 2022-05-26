using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MailSystem.Contracts;
using MailSystem.Contracts.Users;
using MailSystem.Domain.Models;
using MailSystem.Exception;
using MailSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MailSystem.Server.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAll();

            return Ok(_mapper.Map<List<UserContract>>(users));
        }

        /// <response code="404">UserNotFoundException</response>
        [HttpGet]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            try
            {
                var user = await _userService.Get(userId);

                return Ok(_mapper.Map<UserContract>(user));
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new StandardExceptionResponse(ex));
            }
        }

        /// <response code="400">UserEmailAlreadyUsedException</response>
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserContract createUserContract)
        {
            try
            {
                var user = _mapper.Map<User>(createUserContract);
                var userId = await _userService.Create(user);

                return Ok(userId);
            }
            catch(UserEmailAlreadyUsedException ex)
            {
                return BadRequest(new StandardExceptionResponse(ex));
            }
        }

        /// <response code="404">UserNotFoundException</response>
        /// <response code="400">UserEmailAlreadyUsedException</response>
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserContract updateUserContract)
        {
            try
            {
                var user = _mapper.Map<User>(updateUserContract);
                await _userService.Update(user);

                return Ok();

            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new StandardExceptionResponse(ex));
            }
            catch(UserEmailAlreadyUsedException ex)
            {
                return BadRequest(new StandardExceptionResponse(ex));
            }
        }

        /// <response code="404">UserNotFoundException</response>
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            try
            {
                await _userService.Delete(userId);

                return Ok();
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new StandardExceptionResponse(ex));
            }
        }
    }
}