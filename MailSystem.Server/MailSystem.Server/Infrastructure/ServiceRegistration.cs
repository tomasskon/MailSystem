﻿using MailSystem.Services.Interfaces;
using MailSystem.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MailSystem.Server.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();
        }
    }
}