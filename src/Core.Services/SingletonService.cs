using Core.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace Core.Services;

public class SingletonService : BaseService, IService
{
    public SingletonService(ILogger<IService> logger) : base(logger)
    {
        ServiceName = typeof(SingletonService).Name;
    }
}