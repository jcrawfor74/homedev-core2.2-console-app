using System;
using MyMd.PasswordDecrypt.App.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MyMd.PasswordDecrypt.App.DataAccess.Repositories;
using MyMd.PasswordDecrypt.App.Services;

namespace MyMd.PasswordDecrypt.App.Dependencies
{
    public static class DependencyModule
    {
        public static void RegisterDependencies(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IConsoleApp, ConsoleApp>();
            serviceCollection.AddScoped<IMemberRepository, MemberRepository>();
            serviceCollection.AddScoped<IEncryptionService, EncryptionService>();
            
        }
    }
}