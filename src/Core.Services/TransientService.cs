using Core.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace Core.Services;

public class TransientService : BaseService, IService
{
    public TransientService(ILogger<IService> logger) : base(logger)
    {
        ServiceName = typeof(TransientService).Name;
    }
}