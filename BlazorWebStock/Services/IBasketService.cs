using BlazorWebStockLibrary.Model;

namespace BlazorWebStock.Services
{
    public interface IBasketService
    {
        Task RemoveItemFromBasket(string id);
        Task AddItemToBasket(BasketItem item);
        Task<List<BasketItem>> GetItemsFromBasket(string userId);

        event Action<int> OnBasketChanged;
        void FlagEventOnBasketChanged(int qty);
    }
}