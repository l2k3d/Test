using IMPTest.Application.Dto;
using IMPTest.Application.Interfaces;
using IMPTest.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IMPTest.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController(IProductService productService) : Controller
{
    private readonly IProductService _productService = productService;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "", Description = "")]
    public async Task<IActionResult> Products([FromQuery] int? id)
    {
        try
        {
            var result = await _productService.GetProducts(id);
            return HandleResult(result,result.Value);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "", Description = "")]
    public async Task<IActionResult> AddProduct(ProductRecordDto productDto)
    {
        try
        {
            return HandleResult(await _productService.AddProduct(productDto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("/Capacity")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "", Description = "")]
    public async Task<IActionResult> SetProductCapactity([FromBody] CapacityRecordDto capacity)
    {
        try
        {
            return HandleResult(await _productService.SetProductCapacityAsync(capacity));
        }
        catch (Exception ex)
        {
            return BadRequest(ex?.Message);
        }

    }

    [HttpPost("/Receive")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "", Description = "")]
    public async Task<IActionResult> RecieveProduct([FromBody] ProductRecordDto product)
    {
        try
        {
            return HandleResult(await _productService.RecieveProductAsync(product));
        }
        catch (Exception ex)
        {
            return BadRequest(ex?.Message);
        }

    }

    [HttpPost("/Dispatch")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "", Description = "")]
    public async Task<IActionResult> DispatchProduct([FromBody] ProductRecordDto product)
    {
        try
        {
            return HandleResult(await _productService.DispatchProductAsync(product));
        }
        catch (Exception ex)
        {
            return BadRequest(ex?.Message);
        }
    }

    private IActionResult HandleResult<T>(Result<T> result,T? value = default) =>
        result.IsSuccess
                ? Ok(value)
                : result.Error.Code == System.Net.HttpStatusCode.NotFound
                    ? NotFound(result.Error.Description)
                    : BadRequest(result.Error.Description);

}
