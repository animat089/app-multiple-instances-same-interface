using Core.Services.Constants;
using Core.Services.Contracts;

namespace Core.Services;

public class ServiceResolver : IServiceResolver
{
    private readonly IServiceProvider serviceProvider;

    public ServiceResolver(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public IService Provide(ServiceType serviceType)
    {
        var service = serviceType switch
        {
            ServiceType.Singleton => serviceProvider.GetService(typeof(SingletonService)),
            ServiceType.Scoped => serviceProvider.GetService(typeof(ScopedService)),
            ServiceType.Transient => serviceProvider.GetService(typeof(TransientService)),
            _ => null
        };

        return (IService)service;
    }
}