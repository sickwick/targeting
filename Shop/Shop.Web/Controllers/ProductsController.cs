using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Database;
using Shop.Web.Interfaces;
using Shop.Web.Services;

namespace Shop.Web.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController: ControllerBase
    {
        private readonly IProductService _productService;
        
        public ProductsController()
        {
            _productService = new ProductService();
        }
        [HttpGet]
        public Task<IActionResult> GetAllProducts()
        {
            return null;
        }
    }
}