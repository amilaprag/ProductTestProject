using Newtonsoft.Json;
using ProductTestProject.calls;
using ProductTestProject.Request;
using ProductTestProject.Response;
using ProductTestProject.Utility;
using System.Net;
using Xunit.Extensions.Ordering;

namespace ProductTestProject
{
    public class PutProductTest
    {
        //Act
        private string url = "https://api.restful-api.dev/objects/";

        private dynamic savedRequest = JsonUtility.ReadJson("PostProductResponse");

        private ProductRequest request = new ProductRequest
        {
            name = "Apple MacBook Pro 19",
            data = new Request.Data
            {
                price = 300,
                CPUmodel = "Intel Core i7",
                Harddisksize = "3 TB",
                year = 1995
            }
        };

        [Fact, Order(1)]
        public async Task Test_PutProduct_ReturnsSuccess()
        {
            // Act
            url = url + savedRequest.id;

            // Arrange
            dynamic response = await new PutProductRequest().PutProduct(url, request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact, Order(2)]
        public async Task Test_PutProduct_ShouldNotNull()
        {
            // Act
            url = url + savedRequest.id;

            // Arrange
            dynamic response = await new PutProductRequest().PutProduct(url, request);

            // Assert
            Assert.NotNull(response);
        }

        [Fact, Order(3)]
        public async Task Test_PutProduct_CheckContentType()
        {
            // Act
            url = url + savedRequest.id;

            // Arrange
            dynamic response = await new PutProductRequest().PutProduct(url, request);

            // Assert
            Assert.Equal("application/json", response.Content.Headers.ContentType.MediaType);
        }

        [Fact, Order(4)]
        public async Task Test_PutProduct_ValidateSchema()
        {
            // Act
            url = url + savedRequest.id;

            // Arrange
            dynamic response = await new PutProductRequest().PutProduct(url, request);
            var responseObject = await response.Content.ReadAsStringAsync();
            ProductResponse responseModel = JsonConvert.DeserializeObject<ProductResponse>(responseObject);

            // Assert
            Assert.NotNull(responseModel.id);
            Assert.Equal("Apple MacBook Pro 19", responseModel.name);
            Assert.Equal(300, responseModel.data.price);
            Assert.Equal("Intel Core i7", responseModel.data.CPUmodel);
            Assert.Equal("3 TB", responseModel.data.Harddisksize);
            Assert.Equal(1995, responseModel.data.year);
        }

        [Fact, Order(5)]
        public async Task Test_PutProduct_CheckBadRequest()
        {
            // Act
            url = url + savedRequest.id;
            ProductRequest request = null;

            // Arrange
            dynamic response = await new PutProductRequest().PutProduct(url, request);

            // Assert
            Assert.Equal(400, (int)response.StatusCode);
        }
    }
}