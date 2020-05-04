using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Database;
using Shop.Database.Models;
using Shop.Web.Interfaces;
using Shop.Web.Services;

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
        public IActionResult GetAllProducts()
        {
            try
            {
                return Ok(_productService.GetAllProducts());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("product")]
        public IActionResult GetProduct([FromQuery] Product product)
        {
            try
            {
                return Ok(_productService.GetProduct(product.Article));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("size")]
        public IActionResult GetSizes([FromQuery] Product product)
        {
            try
            {
                return Ok(_productService.GetSizes(product.Article));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}