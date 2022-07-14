using BlazorWebStockLibrary.Data;
using BlazorWebStockLibrary.Model;
using MongoDB.Driver;

namespace BlazorWebStock.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _products;
        private readonly IDbConnection _dbConnection;

        public ProductRepository(IDbConnection dbConnection)
        {
            _products = dbConnection.ProductCollection;
            _dbConnection = dbConnection;
        }

        public async Task<List<Product>> GetProducts()
        {
            var res = await _products.FindAsync(_ => true);
            return res.ToList();
        }

        public async Task<Product> GetProduct(string id)
        {
            var res = await _products.FindAsync(p => p.Id == id);
            return res.FirstOrDefault();
        }

        public async Task CreateProduct(Product product)
        {
            await _products.InsertOneAsync(product);
        }

        public async Task DeleteProduct(string id)
        {
            var filter = Builders<Product>.Filter.Eq("Id", id);
            await _products.DeleteOneAsync(filter);
        }
    }
}
