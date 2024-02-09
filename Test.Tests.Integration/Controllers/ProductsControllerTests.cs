using FakeItEasy;
using FluentAssertions;
using Test.Application.Dto;
using Test.Application.Interfaces;
using Test.Application.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Test.Tests.Integration.Controllers;

public class ProductsControllerTests(WebApplicationFactory<Program> sut) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _sut = sut;

    [Fact]
    public async Task Products_ReturnsOkResult()
    {
        // Arrange
        var productServiceFake = A.Fake<IProductService>();
        A.CallTo(() => productServiceFake.GetAllProductsAsync(A<int?>._))
            .Returns(Task.FromResult(Result.Success<IEnumerable<ProductRecordDto>>()));

        var client = _sut.CreateClient();

        // Act
        var response = await client.GetAsync("/api/v1/products");

        // Assert
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

}