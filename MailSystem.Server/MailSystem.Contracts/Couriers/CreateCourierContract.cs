﻿namespace MailSystem.Contracts.Couriers
{
    public class CreateCourierContract
    {
        public string Username { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}