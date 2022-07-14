using BlazorWebStockLibrary.Model;
using MongoDB.Driver;

namespace BlazorWebStockLibrary.Data
{
    public interface IDbConnection
    {
        IMongoCollection<Basket> BasketCollection { get; }
        IMongoCollection<BasketItem> BasketItemCollection { get; }
        string BasketItems { get; set; }
        string Baskets { get; set; }
        string Categories { get; set; }
        IMongoCollection<Category> CategoryCollection { get; }
        string Db { get; set; }
        MongoClient mongoClient { get; }
        IMongoCollection<Product> ProductCollection { get; }
        string Products { get; set; }
        IMongoCollection<User> UserCollection { get; }
        string Users { get; set; }
    }
}