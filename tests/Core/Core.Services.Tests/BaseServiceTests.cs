using Core.Services.Contracts;
using Microsoft.Extensions.Logging;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace Core.Services.Tests;

[ExcludeFromCodeCoverage]
public abstract class BaseServiceTests
{
    protected IService Service { get; set; }

    protected Mock<ILogger<IService>> MockLogger { get; } = new Mock<ILogger<IService>>();

    [Fact]
    public void DoWorkShouldWork()
    {
        // Action
        Service.DoWork();

        // Assert
        MockLogger.Verify(logger => logger.Log(
        It.Is<LogLevel>(logLevel => logLevel == LogLevel.Information),
        It.Is<EventId>(eventId => eventId.Id == 0),
        It.Is<It.IsAnyType>((@object, @type) => @object.ToString().Length > 0),
        It.IsAny<Exception>(),
        It.IsAny<Func<It.IsAnyType, Exception, string>>()),
        Times.Once);
    }
}