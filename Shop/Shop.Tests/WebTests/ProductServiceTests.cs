using FakeLibrary;
using Shop.Database;
using Shop.Web.Interfaces;
using Shop.Web.Services;
using Xunit;

namespace Shop.Tests.WebTests
{
    public class ProductServiceTests
    {
        private readonly IProductService _productService;
        private readonly ProductsStub _productsStub; 

        public ProductServiceTests()
        {
            _productService = new ProductService(new MainDatabase());
            _productsStub = new ProductsStub();
        }

        [Fact]
        public void Is_GetAllProducts_have_check_for_null()
        {
            
        }
    }
}