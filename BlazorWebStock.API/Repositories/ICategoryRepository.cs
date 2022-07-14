using BlazorWebStockLibrary.Model;

namespace BlazorWebStock.API.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategory(string id);
    }
}