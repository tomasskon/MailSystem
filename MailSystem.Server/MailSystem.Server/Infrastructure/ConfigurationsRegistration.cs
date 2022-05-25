using MailSystem.Domain.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MailSystem.Server.Infrastructure
{
    public static class ConfigurationsRegistration
    {
        public static void RegisterConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("JwtToken").Get<JwtTokenConfiguration>());
        }
    }
}