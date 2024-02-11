using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Test.Api.Models.RequestModels;
using Xunit;
using FluentAssertions;

namespace Test.Tests.Integration.Controllers;

public class ProductsControllerTests(WebApplicationFactory<Program> sut) : BaseControllerTest(sut)
{
    [Theory]
    [InlineData("New Product", 50, HttpStatusCode.OK)] // Testing success scenario
    [InlineData(null, 50, HttpStatusCode.BadRequest)] // Testing bad request scenario with null name
    public async Task Adding_Product_Should_Return_Correct_Status(string? name, int quantity, HttpStatusCode expectedStatusCode)
    {
        // Arrange
        var requestContent = new AddProductRequestModel
        {
            Name = name,
            Quantity = quantity
        };

        // Act
        var response = await Post_AddProductRecordAsync(requestContent);

        // Assert
        response.StatusCode.Should().Be(expectedStatusCode);
    }

    [Theory]
    [InlineData(1, 50, HttpStatusCode.OK)] // Testing receiving within capacity
    [InlineData(1, 1000, HttpStatusCode.BadRequest)] // Testing receiving beyond capacity
    public async Task Receiving_Products_Should_Return_Correct_Status(int productId, int quantity, HttpStatusCode expectedStatusCode)
    {
        // Arrange
        await Post_AddProductRecordAsync(new AddProductRequestModel { Name = "Test", Quantity = 50 });
        await Post_AddCapacityRecordAsync(new AddCapacityRequestModel { ProductId = productId, Quantity = 500 });

        // Act
        var response = await Post_ReceiveProductAsync(new ReceiveProductRequestModel { ProductId = productId, Quantity = quantity });

        // Assert
        response.StatusCode.Should().Be(expectedStatusCode);
    }

    [Theory]
    [InlineData(1, 1000, HttpStatusCode.BadRequest)] // Testing dispatching within capacity
    [InlineData(1, 20, HttpStatusCode.OK)] // Testing dispatching beyond held quanitity
    public async Task Dispatch_Products_Should_Return_Correct_Status(int productId, int quantity, HttpStatusCode expectedStatusCode)
    {
        // Arrange
        await Post_AddProductRecordAsync(new AddProductRequestModel
        {
            Name = "Test",
            Quantity = 50
        });

        await Post_AddCapacityRecordAsync(new AddCapacityRequestModel
        {
            ProductId = productId,
            Quantity = 500
        });

        // Act
        var response = await Post_DispatchProductAsync(new DispatchProductRequestModel
        {
            ProductId = productId,
            Quantity = quantity
        });

        // Assert
        response.StatusCode.Should().Be(expectedStatusCode);
    }
}