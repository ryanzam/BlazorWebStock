using BlazorWebStockLibrary.Model;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BlazorWebStockLibrary.Data
{
    public class DbConnection : IDbConnection
    {
        public readonly IConfiguration _configuration;
        public readonly IMongoDatabase _mongoDatabase;
        public string connectionStr = "MongoDB";
        public string Db { get; set; }
        public string Users { get; set; } = "users";
        public string Baskets { get; set; } = "baskets";
        public string BasketItems { get; set; } = "basketItems";
        public string Products { get; set; } = "products";
        public string Categories { get; set; } = "categories";
        public MongoClient mongoClient { get; private set; }
        public IMongoCollection<User> UserCollection { get; private set; }
        public IMongoCollection<Basket> BasketCollection { get; private set; }
        public IMongoCollection<BasketItem> BasketItemCollection { get; private set; }
        public IMongoCollection<Product> ProductCollection { get; private set; }
        public IMongoCollection<Category> CategoryCollection { get; private set; }

        public DbConnection(IConfiguration configuration)
        {
            _configuration = configuration;
            mongoClient = new MongoClient(_configuration.GetConnectionString(connectionStr));
            Db = _configuration["DB"];
            _mongoDatabase = mongoClient.GetDatabase(Db);

            UserCollection = _mongoDatabase.GetCollection<User>(Users);
            BasketCollection = _mongoDatabase.GetCollection<Basket>(Baskets);
            BasketItemCollection = _mongoDatabase.GetCollection<BasketItem>(BasketItems);
            ProductCollection = _mongoDatabase.GetCollection<Product>(Products);
            CategoryCollection = _mongoDatabase.GetCollection<Category>(Categories);
        }
    }
}
