namespace ProductTestProject.calls
{
    public class GetProductRequest
    {
        private HttpClient restClient = new HttpClient();

        public async Task<dynamic> GetProduct(string url)
        {
            var response = await restClient.GetAsync(url);
            return response;
        }
    }
}