using BlazorWebStockLibrary.Data;
using BlazorWebStockLibrary.Model;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BlazorWebStock.API.Repositories
{
	public class BasketRepository : IBasketRepository
	{
		private readonly IDbConnection _dbConnection;
		private readonly IMongoCollection<BasketItem> _basketItems;
		private readonly IMongoCollection<Basket> _basket;

		public BasketRepository(IDbConnection dbConnection)
		{
			_basketItems = dbConnection.BasketItemCollection;
			_basket = dbConnection.BasketCollection;
			_dbConnection = dbConnection;
		}

		public async Task<IEnumerable<BasketItem>> GetItemsFromBasket(string userId)
		{
			var basket = await _basket.Find(b => b.User.Id == userId).SingleAsync();

			if (basket is not null)
			{
				var items = await _basketItems.FindAsync(b => b.Basket.Id == basket.Id);
				return items.ToList();
			}
			return null;
		}

		public async Task<BasketItem> GetItemFromBasket(string id)
		{
			var res = await _basketItems.FindAsync(i => i.Id == id);
			return res.FirstOrDefault();
		}

		public async Task AddItemToBasket(BasketItem item)
		{
			if (await IfExistsBasketItem(item.Basket.Id, item.Product.Id))
			{
				await _basketItems.InsertOneAsync(item);
			}
		}

		public async Task UpdateQuantity(BasketItem item)
		{
			await _basketItems.ReplaceOneAsync(i => i.Id == item.Id, item);
		}

		public async Task RemoveItemFromBasket(string id)
		{
			var filter = Builders<BasketItem>.Filter.Eq("Id", id);
			await _basketItems.DeleteOneAsync(filter);
		}

		public async Task<bool> IfExistsBasketItem(string basketId, string productId)
		{
			var item = await _basketItems.FindAsync(b => b.Id == basketId && b.Product.Id == productId);
			return item != null;
		}
	}
}
