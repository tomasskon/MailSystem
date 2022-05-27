using MailSystem.Repositories.Entities;
using MailSystem.Repositories.Interfaces;
using MailSystem.Repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MailSystem.Server.Infrastructure
{
    public static class RepositoryRegistration
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICourierRepository, CourierRepository>();
            services.AddScoped<IUserPasswordRepository, UserPasswordRepository>();
            services.AddScoped<ICourierPasswordRepository, CourierPasswordRepository>();
            services.AddScoped<IShipmentSizeRepository, ShipmentSizeRepository>();
            services.AddScoped<IMailboxRepository, MailboxRepository>();
            services.AddScoped<IShipmentRepository, ShipmentRepository>();
            services.AddScoped<IShipmentEventRepository, ShipmentEventRepository>();
        }
    }
}
