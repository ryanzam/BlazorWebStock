using BlazorWebStockLibrary.Model;

namespace BlazorWebStock.Services
{
	public interface IBasketService
	{
		Task<BasketItem> AddItemToBasket(BasketItem item);
		Task<IEnumerable<BasketItem>> GetItemsFromBasket(string userId);
	}
}