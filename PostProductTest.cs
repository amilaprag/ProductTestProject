using Newtonsoft.Json;
using ProductTestProject.calls;
using ProductTestProject.Request;
using ProductTestProject.Response;
using ProductTestProject.Utility;
using System.Net;
using Xunit.Extensions.Ordering;

namespace ProductTestProject
{
    [Order(2)]
    public class PostProductTest
    {
        // Arrange
        private ProductRequest request = new ProductRequest
        {
            name = "Apple MacBook Pro 16",
            data = new Request.Data
            {
                price = 100,
                CPUmodel = "Intel Core i9",
                Harddisksize = "1 TB",
                year = 1992
            }
        };

        [Fact]
        public async void Test_PostProduct_ReturnSucess()
        {
            // Act
            dynamic response = await new PostProductRequest().PostProduct(request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Test_PostProduct_ShouldNotNull()
        {
            // Act
            dynamic response = await new PostProductRequest().PostProduct(request);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task Test_PostProduct_CheckContentType()
        {
            // Act
            dynamic response = await new PostProductRequest().PostProduct(request);

            // Assert
            Assert.Equal("application/json", response.Content.Headers.ContentType.MediaType);
        }

        [Fact]
        public async Task Test_PostProduct_ValidateSchema()
        {
            // Act
            dynamic response = await new PostProductRequest().PostProduct(request);
            var responseObject = await response.Content.ReadAsStringAsync();
            ProductResponse responseModel = JsonConvert.DeserializeObject<ProductResponse>(responseObject);

            // Assert
            Assert.NotNull(responseModel.id);
            Assert.Equal("Apple MacBook Pro 16", responseModel.name);
            Assert.Equal(100, responseModel.data.price);
            Assert.Equal("Intel Core i9", responseModel.data.CPUmodel);
            Assert.Equal("1 TB", responseModel.data.Harddisksize);
            Assert.Equal(1992, responseModel.data.year);

            // store Id to use in put request
            JsonUtility.SavedJson(responseModel, "PostProductResponse");
        }

        [Fact]
        public async Task Test_PostProduct_CheckBadRequest()
        {
            // Arrange
            ProductRequest request = null;

            // Act
            dynamic response = await new PostProductRequest().PostProduct(request);

            // Assert
            Assert.Equal(400, (int)response.StatusCode);
        }
    }
}