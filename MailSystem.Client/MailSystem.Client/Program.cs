using System.Threading.Tasks;
using MailSystem.Client.Interfaces;
using MailSystem.Client.Services;
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
            builder.Services.AddHttpClient();
            builder.Services.AddTransient<IUserHttpClient, UserHttpClient>();
            builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            await builder.Build().RunAsync();
        }
    }
}