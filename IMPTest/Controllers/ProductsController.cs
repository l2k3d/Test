using IMPTest.Application.Interfaces;
using IMPTest.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMPTest.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController(IProductService productService) : Controller
{
    private readonly IProductService _productService = productService;

    [HttpGet]
    public async Task<IActionResult> Products()
    {
        var products = await _productService.GetProductsAsync();
        return Ok();
    }

    [HttpPost("/Capacity")]
    public async Task<IActionResult> SetProductCapactity([FromBody] CapacityRecord capacity)
    {
        var result = await _productService.SetProductCapacityAsync(capacity);
        return Ok();
    }

    [HttpPost("/Recieve")]
    public async Task<IActionResult> RecieveProduct([FromBody] ProductRecord product)
    {
        var result = await _productService.RecieveProductAsync(product);
        return Ok();
    }

    [HttpPost("/Dispatch")]
    public async Task<IActionResult> DispatchProduct([FromBody] ProductRecord product)
    {
        var result = await _productService.RecieveProductAsync(product);
        return Ok();
    }

}
