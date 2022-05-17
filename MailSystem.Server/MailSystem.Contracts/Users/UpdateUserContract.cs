﻿using System;

namespace MailSystem.Contracts.Users
{
    public class UpdateUserContract
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}