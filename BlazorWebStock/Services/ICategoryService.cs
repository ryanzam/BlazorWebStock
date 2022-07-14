using BlazorWebStockLibrary.Model;

namespace BlazorWebStock.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategories();
    }
}