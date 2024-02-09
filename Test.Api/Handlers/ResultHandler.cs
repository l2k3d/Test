using Test.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Test.Api.Handlers;

public static class ResultHandler
{
    public static async Task<IActionResult> HandleResult<T>(this Task<Result<T>> resultTask, bool returnValue = false)
    => (await resultTask).IsSuccess 
        ? BuildSuccessResponse(await resultTask, returnValue) 
        : BuildErrorResponse(await resultTask);

    private static IActionResult BuildSuccessResponse<T>(Result<T> result,bool returnValue)
        => result.Value != null && returnValue
        ? new OkObjectResult(result.Value) 
        : new OkResult();

    private static IActionResult BuildErrorResponse<T>(Result<T> result)
        => result.Error.Code switch
        {
            HttpStatusCode.NotFound => new NotFoundObjectResult(result.Error.Description),
            _ => new BadRequestObjectResult(result.Error.Description)
        };
}