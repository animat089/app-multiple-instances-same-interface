using Core.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Threading.Tasks;

namespace Application.DI_Functions;

public class Function_0_Problem : FunctionBase
{

    public Function_0_Problem(IService singletonService, IService scopedService, IService transientService)
    {
        this.singletonService = singletonService;
        this.scopedService = scopedService;
        this.transientService = transientService;
    }

    [FunctionName("DI_Problem")]
    public async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        return await ExecuteFunctionAsync().ConfigureAwait(false);
    }
}