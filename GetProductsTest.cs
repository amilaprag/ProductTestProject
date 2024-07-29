namespace ProductTestProject;

using Newtonsoft.Json;
using ProductTestProject.calls;
using ProductTestProject.Response;
using ProductTestProject.Utility;
using System.Net;
using System.Threading.Tasks;
using Xunit.Extensions.Ordering;

[Order(1)]
public class GetProductsTest
{
    // Arrange
    private string url = ConfigUtility.GetConfiguration();

    [Fact]
    public async Task Test_GetProducts_ReturnSuccess()
    {
        // Act
        dynamic response = await new GetProductRequest().GetProduct(url);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Test_GetProducts_ShouldNotNull()
    {
        // Act
        dynamic response = await new GetProductRequest().GetProduct(url);

        // Assert
        Assert.NotNull(response);
    }

    [Fact]
    public async Task Test_GetProducts_CheckContentType()
    {
        // Act
        dynamic response = await new GetProductRequest().GetProduct(url);

        // Assert
        Assert.Equal("application/json", response.Content.Headers.ContentType.MediaType);
    }

    [Fact]
    public async Task Test_GetProducts_CheckProductSize()
    {
        // Act
        dynamic response = await new GetProductRequest().GetProduct(url);
        var responseObject = await response.Content.ReadAsStringAsync();
        List<ProductResponse> responseModel = JsonConvert.DeserializeObject<List<ProductResponse>>(responseObject);

        // Assert
        Assert.True(responseModel.Count > 0);
    }

    [Fact]
    public async Task Test_GetProducts_ValidateSchema()
    {
        // Act
        dynamic response = await new GetProductRequest().GetProduct(url);
        var responseObject = await response.Content.ReadAsStringAsync();
        List<ProductResponse> responseModel = JsonConvert.DeserializeObject<List<ProductResponse>>(responseObject);

        // Assert
        Assert.NotNull(responseModel[0].id);
        Assert.NotNull(responseModel[0].name);
        Assert.NotNull(responseModel[0].data.color);
        Assert.NotNull(responseModel[0].data.capacity);
    }
}