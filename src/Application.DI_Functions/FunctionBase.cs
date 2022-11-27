using Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.DI_Functions;

public abstract class FunctionBase
{
    protected IService singletonService;
    protected IService scopedService;
    protected IService transientService;

    protected async Task<IActionResult> ExecuteFunctionAsync()
    {
        singletonService.DoWork();
        scopedService.DoWork();
        transientService.DoWork();

        string responseMessage = "This HTTP triggered function executed successfully.";
        return await Task.FromResult(new OkObjectResult(responseMessage)).ConfigureAwait(false);
    }
}