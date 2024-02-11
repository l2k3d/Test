using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;
using FluentAssertions;
using Test.Api.Models.RequestModels;

namespace Test.Tests.Integration.Controllers;

public class CapacityControllerTests(WebApplicationFactory<Program> sut) : BaseControllerTest(sut)
{
    [Fact]
    public async void Capacity_ReturnsOkResult()
    {
        // Arrange
        var addProductRequestModel = new AddProductRequestModel
        {
            Name = "name",
            Quantity = 20
        };

        await Post_AddProductRecordAsync(addProductRequestModel);

        var addCapacityRequestModel = new AddCapacityRequestModel
        {
            ProductId = 1,
            Quantity = 20
        };

        // Act
        var response = await Post_AddCapacityRecordAsync(addCapacityRequestModel);



        // Assert
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}