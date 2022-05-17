﻿using System;
using System.Collections.Generic;
using AutoMapper;
using MailSystem.Contracts.Users;
using MailSystem.Domain.Exceptions;
using MailSystem.Domain.Models;
using MailSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MailSystem.Server.Controllers
{
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
        public IActionResult GetUsers()
        {
            var users = _userService.GetAll();

            return Ok(_mapper.Map<List<UserContract>>(users));
        }

        [HttpGet]
        public IActionResult GetUser(Guid userId)
        {
            try
            {
                var user = _userService.Get(userId);

                return Ok(_mapper.Map<UserContract>(user));
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserContract createUserContract)
        {
            var user = _mapper.Map<User>(createUserContract);
            var userId = _userService.Create(user);

            return Ok(userId);
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UpdateUserContract updateUserContract)
        {
            try
            {
                var user = _mapper.Map<User>(updateUserContract);
                _userService.Update(user);

                return Ok();

            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteUser(Guid userId)
        {
            try
            {
                _userService.Delete(userId);

                return Ok();

            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}