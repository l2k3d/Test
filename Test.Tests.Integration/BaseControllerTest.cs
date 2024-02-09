using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Test.Tests.Integration
{
    public abstract class BaseControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        protected readonly WebApplicationFactory<Program> _sut;
        protected readonly HttpClient _client;

        protected BaseControllerTest(WebApplicationFactory<Program> sut)
        {
            _sut = sut;
            _client = _sut.CreateClient();
        }
    }

}