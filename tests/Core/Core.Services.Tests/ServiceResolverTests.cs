using Core.Services.Constants;
using Core.Services.Contracts;
using Microsoft.Extensions.Logging;
using Moq;

namespace Core.Services.Tests;

public class ServiceResolverTests
{
    private readonly ServiceResolver serviceResolver;

    public ServiceResolverTests()
    {
        var mockedServiceProvider = new Mock<IServiceProvider>();
        var mockedLogger = new Mock<ILogger<IService>>();

        var singletonService = new SingletonService(mockedLogger.Object);
        var scopedService = new ScopedService(mockedLogger.Object);
        var transientService = new TransientService(mockedLogger.Object);

        mockedServiceProvider.Setup(x => x.GetService(typeof(SingletonService))).Returns(singletonService);
        mockedServiceProvider.Setup(x => x.GetService(typeof(ScopedService))).Returns(scopedService);
        mockedServiceProvider.Setup(x => x.GetService(typeof(TransientService))).Returns(transientService);

        serviceResolver = new ServiceResolver(mockedServiceProvider.Object);
    }

    [Theory]
    [InlineData(ServiceType.Singleton, typeof(SingletonService))]
    [InlineData(ServiceType.Scoped, typeof(ScopedService))]
    [InlineData(ServiceType.Transient, typeof(TransientService))]
    public void ShouldResolveType(ServiceType serviceType, Type type)
    {
        var service = serviceResolver.Provide(serviceType);

        Assert.NotNull(service);
        Assert.Equal(type, service.GetType());
    }
}