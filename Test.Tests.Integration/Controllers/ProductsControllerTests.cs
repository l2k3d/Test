using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Test.Api.Models.RequestModels;
using Xunit;
using FluentAssertions;

namespace Test.Tests.Integration.Controllers;

public class ProductsControllerTests(WebApplicationFactory<Program> sut) : BaseControllerTest(sut)
{
    public static TheoryData<AddProductRequestModel, HttpStatusCode> AddingProductData => new()
    {
        { new AddProductRequestModel{Name ="New Product", Quantity= 50 }, HttpStatusCode.OK }, // Testing success scenario
        { new AddProductRequestModel(), HttpStatusCode.BadRequest } // Testing bad request scenario with null request
    };

    public static TheoryData<int, int, HttpStatusCode> ReceivingProductData => new()
    {
        { 1, 50, HttpStatusCode.OK }, // Testing receiving within capacity
        { 1, 1000, HttpStatusCode.BadRequest } // Testing receiving beyond capacity
    };

    public static TheoryData<int, int, HttpStatusCode> DispatchProductData => new()
    {
        { 1, 1000, HttpStatusCode.BadRequest }, // Testing dispatching within capacity
        { 1, 20, HttpStatusCode.OK } // Testing dispatching beyond held quantity
    };

    [Theory]
    [MemberData(nameof(AddingProductData))]
    public async Task Adding_Product_Should_Return_Correct_Status(AddProductRequestModel requestModel, HttpStatusCode expectedStatusCode)
    {

        // Act
        var response = await Post_AddProductRecordAsync(requestModel);

        // Assert
        response.StatusCode.Should().Be(expectedStatusCode);
    }

    [Theory]
    [MemberData(nameof(ReceivingProductData))]
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
    [MemberData(nameof(DispatchProductData))]
    public async Task Dispatch_Products_Should_Return_Correct_Status(int productId, int quantity, HttpStatusCode expectedStatusCode)
    {
        // Arrange
        await Post_AddProductRecordAsync(new AddProductRequestModel { Name = "Test", Quantity = 50 });
        await Post_AddCapacityRecordAsync(new AddCapacityRequestModel { ProductId = productId, Quantity = 500 });

        // Act
        var response = await Post_DispatchProductAsync(new DispatchProductRequestModel { ProductId = productId, Quantity = quantity });

        // Assert
        response.StatusCode.Should().Be(expectedStatusCode);
    }
}
