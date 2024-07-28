using Newtonsoft.Json;
using ProductTestProject.calls;
using ProductTestProject.Response;
using System.Net;
using Xunit.Extensions.Ordering;

namespace ProductTestProject
{
    public class GetProductTest
    {
        // Act
        private string url = "https://api.restful-api.dev/objects/7";

        [Fact, Order(1)]
        public async Task Test_GetProduct_ReturnSuccess()
        {
            // Arrange
            dynamic response = await new GetProductRequest().GetProduct(url);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact, Order(2)]
        public async Task Test_GetProduct_ShouldNotNull()
        {
            // Arrange
            dynamic response = await new GetProductRequest().GetProduct(url);

            // Assert
            Assert.NotNull(response);
        }

        [Fact, Order(3)]
        public async Task Test_GetProduct_CheckContentType()
        {
            // Arrange
            dynamic response = await new GetProductRequest().GetProduct(url);

            // Assert
            Assert.Equal("application/json", response.Content.Headers.ContentType.MediaType);
        }

        [Fact, Order(4)]
        public async Task Test_PutProduct_ShouldReturnNotFound_WhenResourceDoesNotExist()
        {
            // Act
            url = "https://api.restful-api.dev/objects/117";

            // Arrange
            dynamic response = await new GetProductRequest().GetProduct(url);

            // Assert
            Assert.Equal(404, (int)response.StatusCode);
        }

        [Fact, Order(5)]
        public async Task Test_GetProducts_ValidateSchema()
        {
            // Arrange
            dynamic response = await new GetProductRequest().GetProduct(url);
            var responseObject = await response.Content.ReadAsStringAsync();
            ProductResponse responseModel = JsonConvert.DeserializeObject<ProductResponse>(responseObject);

            // Assert
            Assert.NotNull(responseModel.id);
            Assert.NotNull(responseModel.name);
            Assert.NotNull(responseModel.data.color);
            Assert.NotNull(responseModel.data.capacity);
        }
    }
}