using Core.Services.Constants;
using Core.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Threading.Tasks;

namespace Application.DI_Functions;

public class Function_B_DI_Resolver : FunctionBase
{
    public Function_B_DI_Resolver(IServiceResolver serviceResolver)
    {
        singletonService = serviceResolver.Provide(ServiceType.Singleton);
        scopedService = serviceResolver.Provide(ServiceType.Scoped);
        transientService = serviceResolver.Provide(ServiceType.Transient);
    }

    [FunctionName("DI_Resolver")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        return await ExecuteFunctionAsync().ConfigureAwait(false);
    }
}