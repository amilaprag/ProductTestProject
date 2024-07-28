using Newtonsoft.Json;
using ProductTestProject.calls;
using ProductTestProject.Request;
using ProductTestProject.Response;
using System.Net;
using Xunit.Extensions.Ordering;

namespace ProductTestProject
{
    public class DeleteProductTest
    {
        // Act
        private string url = "https://api.restful-api.dev/objects/";

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

        public async Task<string> PostProduct()
        {
            dynamic response = await new PostProductRequest().PostProduct(request);
            var responseObject = await response.Content.ReadAsStringAsync();
            ProductResponse responseModel = JsonConvert.DeserializeObject<ProductResponse>(responseObject);
            return responseModel.id;
        }

        [Fact, Order(1)]
        public async Task Test_DeleteProduct_ReturnSuccess()
        {
            // Act
            url = url + await PostProduct();

            // Arrange
            dynamic response = await new DeleteProdutRequest().DeleteProduct(url);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact, Order(2)]
        public async Task Test_DeleteProduct_ShouldNotNull()
        {
            // Act
            url = url + await PostProduct();

            // Arrange
            dynamic response = await new DeleteProdutRequest().DeleteProduct(url);

            // Assert
            Assert.NotNull(response);
        }

        [Fact, Order(3)]
        public async Task Test_DeleteProduct_CheckContentType()
        {
            // Act
            url = url + await PostProduct();

            // Arrange
            dynamic response = await new DeleteProdutRequest().DeleteProduct(url);

            // Assert
            Assert.Equal("application/json", response.Content.Headers.ContentType.MediaType);
        }

        [Fact, Order(4)]
        public async Task Test_DeleteProduct_ShouldReturnNotFound_WhenResourceDoesNotExist()
        {
            // Act
            url = url + 1111;

            // Arrange
            dynamic response = await new DeleteProdutRequest().DeleteProduct(url);

            // Assert
            Assert.Equal(404, (int)response.StatusCode);
        }

        [Fact, Order(5)]
        public async Task Test_DeleteProduct__ValidateSchema()
        {
            // Act
            string id = await PostProduct();
            url = url + id;

            // Arrange
            dynamic response = await new DeleteProdutRequest().DeleteProduct(url);
            var responseObject = await response.Content.ReadAsStringAsync();
            DeleteProductResponse responseModel = JsonConvert.DeserializeObject<DeleteProductResponse>(responseObject);

            // Assert
            Assert.Equal("Object with id = " + id + " has been deleted.", responseModel.message);
        }
    }
}