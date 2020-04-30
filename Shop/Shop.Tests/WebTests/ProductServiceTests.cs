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
        }

        [Fact]
        public void Is_GetProduct_have_check_parameter()
        {
            Assert.Equal(_productService.GetProduct(default).SerializeObject(), new Product().SerializeObject());
            Assert.Equal(_productService.GetProduct(-1).SerializeObject(), new Product().SerializeObject());
            Assert.Equal(_productService.GetProduct(Int64.MaxValue).SerializeObject(), new Product().SerializeObject());
        }

        [Fact]
        public void Is_GetProduct_Return_Correct_data()
        {
            Assert.Equal(_productService.GetProduct(12345).SerializeObject(),
                _productsStub.Products.FirstOrDefault(i => i.Article == 12345).SerializeObject());
            Assert.Equal(_productService.GetProduct(12345).Id.SerializeObject(),
                _productsStub.Products.FirstOrDefault(i => i.Article == 12345).Id.SerializeObject());
            Assert.NotEqual(_productService.GetProduct(12345).Id.SerializeObject(),
                _productsStub.Products.FirstOrDefault(i => i.Article == 12454).Id.SerializeObject());
        }

        [Fact]
        public void Is_GetSizes_have_check_parameter()
        {
            Assert.Equal(_productService.GetSizes(default).SerializeObject(), new Product().SerializeObject());
            Assert.Equal(_productService.GetSizes(-1).SerializeObject(), new Product().SerializeObject());
            Assert.Equal(_productService.GetSizes(Int64.MaxValue).SerializeObject(), new Product().SerializeObject());
        }

        [Fact]
        public void Is_GetSizes_return_correct_data()
        {
            Assert.Equal(_productService.GetSizes(12345).SerializeObject(),
                _productsStub.Products.FirstOrDefault(i => i.Article == 12345).SizesAvailable.SerializeObject());
            Assert.True(_productService.GetSizes(12345).Any());
                Assert.NotEqual(_productService.GetSizes(12345).SerializeObject(),
                _productsStub.Products.FirstOrDefault(i => i.Article == 12454).SizesAvailable.SerializeObject());
        }
    }
}