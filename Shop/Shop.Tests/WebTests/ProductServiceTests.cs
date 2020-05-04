using System;
using System.Linq;
using FakeLibrary;
using Shop.Database;
using Shop.Database.Models;
using Shop.Tests.Mocks;
using Shop.Web.Interfaces;
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
            _productService = new ProductService();
            _productsStub = new ProductsStub();
            _databaseMock = new DatabaseMock();
        }

        [Fact]
        public void Is_GetAllProducts_have_check_for_null()
        {
            Assert.NotNull(new ProductService().SerializeObject());
            Assert.NotNull(new ProductService().GetAllProducts().SerializeObject());
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
            Assert.Throws<ArgumentException>(() => _productService.GetProduct(default));
            Assert.Throws<ArgumentException>(() => _productService.GetProduct(-1));
            Assert.Throws<ArgumentException>(() => _productService.GetProduct(long.MaxValue));
            Assert.Throws<ArgumentException>(() => _productService.GetProduct(long.MinValue));
            Assert.Equal(_productService.GetProduct(12345).SerializeObject(),
                _productsStub.Products.FirstOrDefault(i => i.Article == 12345).SerializeObject());
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
            Assert.Throws<ArgumentNullException>(() => _productService.GetSizes(default));
            Assert.Throws<ArgumentNullException>(() => _productService.GetSizes(-1));
            Assert.Throws<ArgumentNullException>(() => _productService.GetSizes(long.MaxValue));
            Assert.Throws<ArgumentNullException>(() => _productService.GetSizes(long.MinValue));
            Assert.Equal(_productService.GetSizes(12345).SerializeObject(),
                _productsStub.Products.FirstOrDefault(i => i.Article == 12345).SizesAvailable.SerializeObject());
        }

        [Fact]
        public void Is_GetSizes_return_correct_data()
        {
            Assert.Equal(_productService.GetSizes(12345).SerializeObject(),
                _productsStub.Products.FirstOrDefault(i => i.Article == 12345).SizesAvailable.SerializeObject());
            Assert.True(_productService.GetSizes(12345).Any());
            Assert.NotEqual(_productService.GetSizes(12345).SerializeObject(),
                _productsStub.Products.FirstOrDefault(i => i.Article == 12454).SizesAvailable.SerializeObject());
            for (long i = 1; i < 20000; i++)
            {
                if (i == 12345 || i == 12454)
                {
                    Assert.Equal(_productService.GetSizes(i).SerializeObject(),
                        _productsStub.Products.FirstOrDefault(product => product.Article == i).SizesAvailable
                            .SerializeObject());
                }
                else
                {
                    Assert.Throws<ArgumentException>(() => _productService.GetSizes(i));   
                }
            }
        }

        [Fact]
        public void Is_AddNewProduct_have_check_parameter()
        {
            Assert.Throws<ArgumentNullException>(() => _productService.AddNewProduct(default).SerializeObject());
            Assert.Throws<ArgumentNullException>(() => _productService.AddNewProduct(new Product(){Article = -1}));
            Assert.Throws<ArgumentNullException>(() => _productService.AddNewProduct(new Product(){Article = long.MaxValue}));
            Assert.Throws<ArgumentNullException>(() => _productService.AddNewProduct(new Product(){Article = long.MinValue}));
        }

        [Fact]
        public void Is_AddNewProduct_correctly_add_data()
        {
            
        }
    }
}