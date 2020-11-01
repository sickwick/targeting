using System;
using Microsoft.AspNetCore.Mvc;
using Shop.Storage.Interfaces.Services;
using Shop.Storage.Models;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                return Ok(_productService.GetAllProducts());
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("product")]
        public IActionResult GetProduct([FromQuery] Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            try
            {
                return Ok(_productService.GetProduct(product.Article));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("size")]
        public IActionResult GetSizes([FromQuery] Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            try
            {
                return Ok(_productService.GetSizes(product.Article));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            
            try
            {
                return Ok(_productService.AddNewProduct(product));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}