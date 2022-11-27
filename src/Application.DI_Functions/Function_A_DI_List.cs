using Core.Services;
using Core.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DI_Functions;

public class Function_A_DI_List : FunctionBase
{
    public Function_A_DI_List(IEnumerable<IService> services)
    {
        singletonService = services.First(svc => svc.GetType() == typeof(SingletonService));
        scopedService = services.First(svc => svc.GetType() == typeof(ScopedService));
        transientService = services.First(svc => svc.GetType() == typeof(TransientService));
    }

    [FunctionName("DI_List")]
    public async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        return await ExecuteFunctionAsync().ConfigureAwait(false);
    }
}