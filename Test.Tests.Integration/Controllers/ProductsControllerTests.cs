using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Test.Api.Models.RequestModels;
using Xunit;

namespace Test.Tests.Integration.Controllers;

public class ProductsControllerTests(WebApplicationFactory<Program> sut) : BaseControllerTest(sut)
{
    [Fact]
    public async Task Receiving_Products_Beyond_Capacity_Should_Return_Error()
    {
        // Arrange
        var requestContent = new ReceiveProductRequestModel
        {
            ProductId = 1,
            Quantity = 1000
        };

        // Act
        var response = await Post_ReceiveProductAsync(requestContent);

        // Assert
        response.StatusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Receiving_Products_Within_Capacity_Should_Update_Quantity()
    {
        // Arrange
        var requestContent = new ReceiveProductRequestModel { ProductId = 1, Quantity = 100 };

        // Act
        var response = await Post_ReceiveProductAsync(requestContent);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Dispatching_Products_Should_Update_Quantity()
    {
        // Arrange
        var requestContent = new DispatchProductRequestModel { ProductId = 1, Quantity = 20 };

        // Act
        var response = await Post_DispatchProductAsync(requestContent);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Retrieving_Product_Inventory_Should_Return_Correct_Inventory_Data()
    {
        // Arrange
        var requestContent = new DispatchProductRequestModel { ProductId = 1, Quantity = 20 };

        // Act
        var response = await Post_DispatchProductAsync(requestContent);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
