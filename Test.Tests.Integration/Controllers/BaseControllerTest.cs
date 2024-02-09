using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using Test.Api.Models.RequestModels;
using Xunit;

namespace Test.Tests.Integration.Controllers;

public abstract class BaseControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    protected readonly WebApplicationFactory<Program> _sut;
    protected readonly HttpClient _client;

    protected BaseControllerTest(WebApplicationFactory<Program> sut)
    {
        _sut = sut;
        _client = _sut.CreateClient();
    }

    public async Task<HttpResponseMessage> Post_AddCapacityRecordAsync(AddCapacityRequestModel requestBody)
    {
        return await _client.PostAsJsonAsync("/api/v1/products/capacity", requestBody);
    }

    public async Task<HttpResponseMessage> Post_AddProductRecordAsync(AddProductRequestModel requestBody)
    => await _client.PostAsJsonAsync("/api/v1/products", requestBody);

    public async Task<HttpResponseMessage> Post_ReceiveProductAsync(ReceiveProductRequestModel requestBody)
    {
        return await _client.PostAsJsonAsync("/api/v1/products/receive", requestBody);
    }

    public async Task<HttpResponseMessage> Post_DispatchProductAsync(DispatchProductRequestModel requestBody)
    {
        return await _client.PostAsJsonAsync("/dispatch", requestBody);
    }

    public async Task<HttpResponseMessage> Get_ProductsAsync(int? id = null)
    {
        var requestUri = "/api/v1/products";
        if (id.HasValue)
        {
            requestUri += $"?id={id}";
        }
        return await _client.GetAsync(requestUri);
    }
}