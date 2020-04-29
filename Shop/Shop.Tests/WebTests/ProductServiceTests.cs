using System;
using System.Linq;
using FakeLibrary;
using Shop.Database;
using Shop.Tests.Mocks;
using Shop.Web.Interfaces;
using Shop.Web.Models;
using Shop.Web.Services;
using Xunit;

namespace Shop.Tests.WebTests
{
    public class ProductServiceTests
    {
        private readonly IProductService _productService;
        private readonly ProductsStub _productsStub;
        private readonly DatabaseMock _databaseMock;

        public ProductServiceTests()
        {
            _productService = new ProductService(new DatabaseMock());
            _productsStub = new ProductsStub();
            _databaseMock = new DatabaseMock();
        }

        [Fact]
        public void Is_GetAllProducts_have_check_for_null()
        {
            Assert.NotNull(new ProductService(_databaseMock).SerializeObject());
            Assert.NotNull(new ProductService(null).GetAllProducts().SerializeObject());
        }

        [Fact]
        public void Is_GetAllProducts_return_correct_data()
        {
            Assert.Equal(_productService.GetAllProducts().SerializeObject(),
                _productsStub.Products.SerializeObject());
            Assert.Equal(_productService.GetAllProducts().SerializeObject(),
                _productsStub.Products.SerializeObject());
        }

        [Fact]
        public void Is_GetProduct_have_check_for_parameter()
        {
            Assert.Null(_productService.GetProduct(default).SerializeObject());
            Assert.Null(_productService.GetProduct(-1).SerializeObject());
            Assert.Null(_productService.GetProduct(Int64.MaxValue));
        }

        [Fact]
        public void Is_GetProduct_Return_Correct_data()
        {
            Assert.Equal(_productService.GetProduct(12345).SerializeObject(),
                _productsStub.Products.FirstOrDefault(i => i.Article == 12345).SerializeObject());
        }
    }
}