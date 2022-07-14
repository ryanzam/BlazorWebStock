using BlazorWebStock.API.Repositories;
using BlazorWebStockLibrary.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebStock.API.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            try
            {
                var categories = await _categoryRepository.GetCategories();
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception e)
            {
                //Simple return status code error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occured :" + e);
            }
        }
    }
}
