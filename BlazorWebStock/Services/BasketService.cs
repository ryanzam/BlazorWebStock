using BlazorWebStockLibrary.Model;
using System.Net.Http.Json;

namespace BlazorWebStock.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BasketItem>> GetItemsFromBasket(string userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Basket/{userId}/GetItemsFromBasket");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<BasketItem>>();
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<BasketItem> AddItemToBasket(BasketItem item)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Basket", item);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<BasketItem>();
                }
                else
                {
                    var msg = await response.Content.ReadAsStringAsync();
                    throw new Exception(msg);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
