using Test.Application.Dto;
using Test.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Test.Api.Handlers;
using AutoMapper;
using Test.Api.Models;

namespace Test.Controllers;

[Route("api/v1/products/[controller]")]
public class CapacityController(ICapacityService capacityService,IMapper mapper)
    : BaseTestController<CapacityRecordDto>(mapper)
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "", Description = "")]
    public async Task<IActionResult> SetProductCapacity([FromBody] AddCapacityRequestModel capacity)
        => await capacityService
        .SetProductCapacityAsync(MapToDto(capacity))
        .HandleResult();
}