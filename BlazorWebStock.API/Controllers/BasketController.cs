using BlazorWebStock.API.Repositories;
using BlazorWebStockLibrary.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebStock.API.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class BasketController : Controller
    {
        private readonly IBasketRepository _basketRepository;

        private readonly IProductRepository _productRepository;

        public BasketController(IBasketRepository basketRepository, IProductRepository productRepository)
        {
            _basketRepository = basketRepository;
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BasketItem>> GetItemFromBasket(string id)
        {
            try
            {
                var items = await _basketRepository.GetItemFromBasket(id);
                if (items == null)
                {
                    return NotFound();
                }

                var product = await _productRepository.GetProduct(items.Id);
                if (product == null)
                {
                    return NotFound();
                }
                items.Product = product;
                return Ok(items);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("{userId}/GetItemsFromBasket")]
        public async Task<ActionResult<IEnumerable<BasketItem>>> GetItemsFromBasket(string userId)
        {
            try
            {
                var basketItem = await _basketRepository.GetItemsFromBasket(userId);
                if (basketItem == null)
                {
                    return NoContent();
                }
                return Ok(basketItem);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task PostItemToBasket([FromBody] BasketItem item)
        {
            try
            {
                await _basketRepository.AddItemToBasket(item);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
