using AdventOfCode2024.Policies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);
            var config = builder.Build();
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .Enrich.FromLogContext()
                .CreateLogger();

            Log.Logger.Information("Application Starting");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddHttpClient(config["HttpClientImmediate"])
                    .AddPolicyHandler(policy => new ClientPolicy().ImmediateHttpRetry);
                    services.AddHttpClient(config["HttpClientBackoff"])
                    .AddPolicyHandler(policy => new ClientPolicy().ExponentialHttpRetry);
                    services.AddScoped<MyApplication>();
                }).UseSerilog()
                .Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                //try
                //{
                    var myService = services.GetRequiredService<MyApplication>();
                    await myService.RunProgram();
                //}
                //catch (Exception ex)
                //{
                //    Log.Fatal(ex, $"ERROR: {ex.Message}");
                //}
                //finally
                //{
                //    Log.CloseAndFlush();
                //}
            }
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            Environment.CurrentDirectory = AppContext.BaseDirectory;
            builder.SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables()
                .AddUserSecrets<Program>();
        }
    }
}
