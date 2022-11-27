namespace Core.Services.Tests;

public class SingletonServiceTests : BaseServiceTests
{
    public SingletonServiceTests()
    {
        Service = new SingletonService(MockLogger.Object);
    }
}