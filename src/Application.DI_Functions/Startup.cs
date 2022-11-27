using Application.A_DI_List_ServiceProvider;
using Core.Services;
using Core.Services.Contracts;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Application.A_DI_List_ServiceProvider
{
    internal class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // For Function A/B - DI with Lists and IServiceProvider
            builder.Services.AddSingleton<IService, SingletonService>();
            builder.Services.AddScoped<IService, ScopedService>();
            builder.Services.AddTransient<IService, TransientService>();

            // For Function C - DI with a Resolver (inspired by Factory pattern)
            builder.Services.AddSingleton<SingletonService>();
            builder.Services.AddScoped<ScopedService>();
            builder.Services.AddTransient<TransientService>();
            builder.Services.AddSingleton<IServiceResolver, ServiceResolver>();
        }
    }
}