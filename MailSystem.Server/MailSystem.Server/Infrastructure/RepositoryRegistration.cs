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
            services.AddSingleton<ICourierRepository, CourierRepository>();
            services.AddSingleton<IUserPasswordRepository, UserPasswordRepository>();
            services.AddSingleton<ICourierPasswordRepository, CourierPasswordRepository>();
            services.AddSingleton<IShipmentSizeRepository, ShipmentSizeRepository>();
            services.AddSingleton<IMailboxRepository, MailboxRepository>();
        }
    }
}
