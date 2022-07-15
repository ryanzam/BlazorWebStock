using BlazorWebStockLibrary.Model;
using System.Net.Http.Json;

namespace BlazorWebStock.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public event Action<int> OnBasketChanged;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BasketItem>> GetItemsFromBasket(string userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Basket/{userId}/GetItemsFromBasket");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<BasketItem>>();
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

        public async Task AddItemToBasket(BasketItem item)
        {
            try
            {
                await _httpClient.PostAsJsonAsync("api/Basket", item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task RemoveItemFromBasket(string id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Basket/{id}");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void FlagEventOnBasketChanged(int qty)
        {
            if (OnBasketChanged != null)
            {
                OnBasketChanged.Invoke(qty);
            }
        }
    }
}
