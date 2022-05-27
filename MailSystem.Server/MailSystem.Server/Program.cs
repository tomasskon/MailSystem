using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace MailSystem.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            
            
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                }).UseSerilog(
                (context, configuration) =>
                {
                    configuration
                        .ReadFrom
                        .Configuration(
                            context.Configuration.GetSection("Serilog"))
                        .WriteTo.Console()
                        .WriteTo.File("Logs/logs.txt")
                        .MinimumLevel.Debug();
                });

            return host;
        }
    }
}