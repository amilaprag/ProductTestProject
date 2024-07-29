using ProductTestProject.Request;
using System.Net.Http.Json;

namespace ProductTestProject.calls
{
    public class PutProductRequest
    {
        private HttpClient restClient = new HttpClient();

        public async Task<dynamic> PutProduct(String url, ProductRequest productRequest)
        {
            var result = await restClient.PutAsJsonAsync(url, productRequest);
            return result;
        }
    }
}