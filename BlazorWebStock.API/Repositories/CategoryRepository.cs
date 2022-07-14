using BlazorWebStockLibrary.Data;
using BlazorWebStockLibrary.Model;
using MongoDB.Driver;

namespace BlazorWebStock.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbConnection _dbconnection;
        private readonly IMongoCollection<Category> _categories;

        public CategoryRepository(IDbConnection dbconnection)
        {
            _categories = dbconnection.CategoryCollection;
            _dbconnection = dbconnection;
        }

        public async Task<List<Category>> GetCategories()
        {
            var res = await _categories.FindAsync(_ => true);
            return res.ToList();
        }

        public async Task<Category> GetCategory(string id)
        {
            var res = await _categories.FindAsync(c => c.Id == id);
            return res.FirstOrDefault();
        }
    }
}
