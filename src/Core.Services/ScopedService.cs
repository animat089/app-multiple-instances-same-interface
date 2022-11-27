using Core.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace Core.Services;

public class ScopedService : BaseService, IService
{
    public ScopedService(ILogger<IService> logger) : base(logger)
    {
        ServiceName = typeof(ScopedService).Name;
    }
}