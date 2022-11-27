namespace Core.Services.Tests;

public class TransientServiceTests : BaseServiceTests
{
    public TransientServiceTests()
    {
        Service = new TransientService(MockLogger.Object);
    }
}