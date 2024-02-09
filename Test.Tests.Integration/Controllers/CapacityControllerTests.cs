using FluentAssertions;
using Test.Application.Dto;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace Test.Tests.Integration.Controllers;

public class CapacityControllerTests(WebApplicationFactory<Program> sut) : BaseControllerTest(sut)
{

    [Fact]
    public async Task Capacity_ReturnsOkResult()
    {

        var productRequestBody = new ProductRecordDto
        {
            Id = 0,
            Quantity = 10,
        };

        await _client.PostAsJsonAsync("/api/v1/products/", productRequestBody);

        var requestBody = new CapacityRecordDto
        {
            ProductId = 1,
            Quantity = 20,
        };

        var response = await _client.PostAsJsonAsync("/api/v1/products/capacity", requestBody);

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

}