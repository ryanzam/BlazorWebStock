using BlazorWebStockLibrary.Model;
using System.Net.Http.Json;

namespace BlazorWebStock.Services
{
    public class ProductService : IProductServices
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Product> GetProduct(string id)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<Product>($"api/Product/{id}");
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("api/Product");
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
