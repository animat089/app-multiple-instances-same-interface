namespace Core.Services.Tests;

public class ScopedServiceTests : BaseServiceTests
{
    public ScopedServiceTests()
    {
        Service = new ScopedService(MockLogger.Object);
    }
}