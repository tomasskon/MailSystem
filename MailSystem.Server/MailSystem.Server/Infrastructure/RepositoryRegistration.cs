using MailSystem.Repositories.Interfaces;
using MailSystem.Repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MailSystem.Server.Infrastructure
{
    public static class RepositoryRegistration
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
        }
    }
}