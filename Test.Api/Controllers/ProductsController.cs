using Test.Application.Dto;
using Test.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Test.Api.Handlers;
using AutoMapper;
using Test.Api.Models.RequestModels;

namespace Test.Controllers;

[Route("api/v1/[controller]")]
public class ProductsController(IProductService productService,IMapper mapper) 
    : BaseTestController<ProductRecordDto>(mapper)
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "", Description = "")]
    public async Task<IActionResult> Products([FromQuery] int? id)
        => await productService
        .GetAllProductsAsync(id)
        .HandleResult(true);

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "", Description = "")]
    public async Task<IActionResult> AddProduct(AddProductRequestModel request)
        => await productService
        .AddAsync(MapToDto(request))
        .HandleResult();

    [HttpPost("/Receive")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "", Description = "")]
    public async Task<IActionResult> ReceiveProduct([FromBody] ReceiveProductRequestModel request)
        => await productService
        .ReceiveProductAsync(MapToDto(request))
        .HandleResult();

    [HttpPost("/Dispatch")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "", Description = "")]
    public async Task<IActionResult> DispatchProduct([FromBody] DispatchProductRequestModel request)
        => await productService
        .DispatchProductAsync(MapToDto(request))
        .HandleResult();

}