using System;
using System.Net.Http;
using System.Threading.Tasks;
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
            
            await builder.Build().RunAsync();
        }
    }
}