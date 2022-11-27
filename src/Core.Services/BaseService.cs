using Core.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace Core.Services;

public abstract class BaseService : IService
{
    private readonly ILogger<IService> logger;
    protected string ServiceName { get; set; }

    public BaseService(ILogger<IService> logger)
    {
        this.logger = logger;
    }

    public virtual void DoWork()
    {
        logger.LogInformation("Successfully executed {0}", ServiceName);
    }
}