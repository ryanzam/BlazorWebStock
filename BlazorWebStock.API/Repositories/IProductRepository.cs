using BlazorWebStockLibrary.Model;

namespace BlazorWebStock.API.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(string id);
        Task<List<Product>> GetProducts();
    }
}