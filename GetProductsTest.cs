namespace ProductTestProject;

using Newtonsoft.Json;
using ProductTestProject.calls;
using ProductTestProject.Response;
using System.Net;
using System.Threading.Tasks;

public class GetProductsTest
{
    private string url = "https://api.restful-api.dev/objects";

    [Fact]
    public async Task Test_GetProducts_ReturnsSuccess()
    {
        // Arrange
        dynamic response = await new GetProductRequest().GetProduct(url);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Test_GetProducts_ShouldNotNull()
    {
        // Arrange
        dynamic response = await new GetProductRequest().GetProduct(url);

        // Assert
        Assert.NotNull(response);
    }

    [Fact]
    public async Task Test_GetProducts_CheckContentType()
    {
        // Arrange
        dynamic response = await new GetProductRequest().GetProduct(url);

        // Assert
        Assert.Equal("application/json", response.Content.Headers.ContentType.MediaType);
    }

    [Fact]
    public async Task Test_GetProducts_CheckProductSize()
    {
        // Arrange
        dynamic response = await new GetProductRequest().GetProduct(url);
        var responseObject = await response.Content.ReadAsStringAsync();
        List<ProductResponse> responseModel = JsonConvert.DeserializeObject<List<ProductResponse>>(responseObject);

        // Assert
        Assert.True(responseModel.Count > 0);
    }

    [Fact]
    public async Task Test_GetProducts_ValidateSchema()
    {
        // Arrange
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