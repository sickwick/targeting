using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Web.Interfaces;

namespace Shop.Web.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController: ControllerBase
    {
        private readonly IProductService _productService;
        
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public Task<IActionResult> GetAllProducts()
        {
            return null;
        }
    }
}