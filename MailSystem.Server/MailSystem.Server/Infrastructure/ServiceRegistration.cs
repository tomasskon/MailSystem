using DinkToPdf;
using DinkToPdf.Contracts;
using MailSystem.Services.Interfaces;
using MailSystem.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MailSystem.Server.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<ICourierService, CourierService>();
            services.AddScoped<IShipmentSizeService, ShipmentSizeService>();
            services.AddScoped<IMailboxService, MailboxService>();
            services.AddScoped<IShipmentService, ShipmentService>();
            services.AddScoped<IShipmentEventService, ShipmentEventService>();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddScoped<IDynamicInvoiceService, DynamicInvoiceService>();
            services.AddScoped<InvoiceService>();
            services.AddScoped<InvoiceServiceLithuanian>();
        }
    }
}
