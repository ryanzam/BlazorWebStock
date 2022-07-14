using BlazorWebStockLibrary.Model;
using System.Net.Http.Json;

namespace BlazorWebStock.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<Category>>("api/Category");
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
