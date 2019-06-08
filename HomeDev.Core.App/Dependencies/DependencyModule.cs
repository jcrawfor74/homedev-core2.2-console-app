using System;
using HomeDev.Core.App.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HomeDev.Core.App.Dependencies
{
    public static class DependencyModule
    {
        public static void RegisterDependencies(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IConsoleApp, ConsoleApp>(); 
        }
    }
}