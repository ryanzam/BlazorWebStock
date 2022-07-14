using BlazorWebStockLibrary.Model;

namespace BlazorWebStock.API.Repositories
{
    public interface IBasketRepository
    {
        Task AddItemToBasket(BasketItem item);
        Task<IEnumerable<BasketItem>> GetItemsFromBasket(string userId);
        Task<BasketItem> GetItemFromBasket(string id);
        Task UpdateQuantity(BasketItem item);
        Task RemoveItemFromBasket(string id);
    }
}