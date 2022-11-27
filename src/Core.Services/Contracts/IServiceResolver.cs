using Core.Services.Constants;

namespace Core.Services.Contracts;

public interface IServiceResolver
{
    IService Provide(ServiceType serviceType);
}