using ProductTestProject.Request;
using ProductTestProject.Utility;
using System.Net.Http.Json;

namespace ProductTestProject.calls
{
    public class PostProductRequest
    {
        private HttpClient restClient = new HttpClient();
        private string url = ConfigUtility.GetConfiguration();

        public async Task<dynamic> PostProduct(ProductRequest productRequest)
        {
            var result = await restClient.PostAsJsonAsync(url, productRequest);
            return result;
        }
    }
}