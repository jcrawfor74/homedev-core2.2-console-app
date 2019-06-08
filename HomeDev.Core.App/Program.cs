using System;
using System.IO;
using HomeDev.Core.App.Config;
using HomeDev.Core.App.Dependencies;
using HomeDev.Core.App.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace HomeDev.Core.App
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            var services = SetupServices();
            _serviceProvider = services.BuildServiceProvider();

            var consoleApp = _serviceProvider.GetService<IConsoleApp>();
            consoleApp.Run();
        }


        static IServiceCollection SetupServices() 
        {
            var serviceCollection = new ServiceCollection();

            DependencyModule.RegisterDependencies(serviceCollection);
            SetupLogging(serviceCollection);
            SetupConfiguration(serviceCollection); 

            return serviceCollection;
        }

        static void SetupLogging(IServiceCollection serviceCollection) 
        {
            serviceCollection
                .AddLogging(opt => {
                    //opt.AddConsole();
                    opt.AddSerilog();
                });
            
            // Initialise Serilog
            Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Debug()
                 .Enrich.FromLogContext()
                 .WriteTo.Console(restrictedToMinimumLevel : LogEventLevel.Information)
                 .WriteTo.File(".\\logs\\consoleapp.log", rollingInterval : RollingInterval.Day)
                 .CreateLogger();

        }

        static void SetupConfiguration(IServiceCollection serviceCollection) 
        {
            // build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            serviceCollection.AddOptions();
            serviceCollection.Configure<AppSettings>(configuration.GetSection("AppSettings"));
        }
    }
}
