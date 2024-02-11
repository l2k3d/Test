using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;
using FluentAssertions;
using Test.Api.Models.RequestModels;

namespace Test.Tests.Integration.Controllers
{
    public class CapacityControllerTests(WebApplicationFactory<Program> sut) : BaseControllerTest(sut)
    {
        public static TheoryData<AddProductRequestModel, AddCapacityRequestModel, HttpStatusCode> CapacityData => new()
        {
            { new AddProductRequestModel { Name = "name", Quantity = 20 }, new AddCapacityRequestModel { ProductId = 1, Quantity = 20 }, HttpStatusCode.OK }
        };

        [Theory]
        [MemberData(nameof(CapacityData))]
        public async void Capacity_Returns_Correct_Status(AddProductRequestModel addProductRequestModel, AddCapacityRequestModel addCapacityRequestModel, HttpStatusCode expectedStatusCode)
        {
            // Arrange
            await Post_AddProductRecordAsync(addProductRequestModel);

            // Act
            var response = await Post_AddCapacityRecordAsync(addCapacityRequestModel);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(expectedStatusCode);
        }
    }
}
