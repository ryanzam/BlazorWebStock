using BlazorWebStock.API.Repositories;
using BlazorWebStockLibrary.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebStock.API.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                var products = await _productRepository.GetProducts();

                if (products == null)
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occured :" + e);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct(string id)
        {
            try
            {
                var product = await _productRepository.GetProduct(id);

                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occured :" + e);
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateProduct([FromBody] Product product)
        //{
        //    try
        //    {
        //        await _productRepository.CreateProduct(product);
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error occured :" + e);
        //    }
        //}
    }
}
