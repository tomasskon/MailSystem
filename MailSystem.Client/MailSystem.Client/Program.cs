using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using MailSystem.Services.Interfaces;
using MailSystem.Services.Services;
using MailSystem.Http.HttpClients;
using MailSystem.Http.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MailSystem.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddHttpClient("Server", httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://localhost:5001/");
            });
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddTransient<IUserHttpClient, UserHttpClient>();
            builder.Services.AddTransient<IAuthenticationHttpClient, AuthenticationHttpClient>();
            builder.Services.AddTransient<IAuthorizedHttpClient, AuthorizedHttpClient>();
            builder.Services.AddTransient<IShipmentSizeHttpClient, ShipmentSizeHttpClient>();
            builder.Services.AddTransient<IMailboxHttpClient, MailboxHttpClient>();
            builder.Services.AddTransient<IShipmentHttpClient, ShipmentHttpClient>();
            builder.Services.AddTransient<IShipmentEventHttpClient, ShipmentEventHttpClient>();
            builder.Services.AddTransient<ICourierHttpClient, CourierHttpClient>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<IStorageService, StorageService>();
            await builder.Build().RunAsync();
        }
    }
}