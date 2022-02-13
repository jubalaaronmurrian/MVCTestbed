using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace MVCTestbed
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                   
                    string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                    webBuilder.ConfigureAppConfiguration((context, config) => {

                        IHostEnvironment env = context.HostingEnvironment;

                       config.AddEnvironmentVariables();
                        config.AddJsonFile($"appSettings.{env.EnvironmentName}.json");
                    
                    });
                    
                    webBuilder.UseStartup<Startup>();
                });
    }
}
