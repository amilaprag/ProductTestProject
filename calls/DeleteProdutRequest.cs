namespace ProductTestProject.calls
{
    public class DeleteProdutRequest
    {
        private HttpClient restClient = new HttpClient();

        public async Task<dynamic> DeleteProduct(String url)
        {
            var response = await restClient.DeleteAsync(url);
            return response;
        }
    }
}