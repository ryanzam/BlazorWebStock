using BlazorWebStockLibrary.Model;

namespace BlazorWebStock.Services
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(string id);
    }
}
