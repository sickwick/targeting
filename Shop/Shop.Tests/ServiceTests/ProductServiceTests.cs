using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Shop.Database.Stubs;
using Shop.Storage.Extensions;
using Shop.Storage.Interfaces.Services;
using Shop.Storage.Models;
using Shop.Tests.Mocks;
using Xunit;

namespace Shop.Tests.ServiceTests
{
    public class ProductServiceTests
    {
        public ProductServiceTests()
        {
            _productService = ProductServiceContainerConfig.GetContainer().GetService<IProductService>();
            _productsStub = new ProductsStub();
            _databaseMock = new DatabaseMock();
        }

        private readonly IProductService _productService;
        private readonly ProductsStub _productsStub;
        private readonly DatabaseMock _databaseMock;

        [Fact]
        public void Is_AddNewProduct_correctly_add_data()
        {
            Assert.True(_productService.AddNewProduct(new Product() { Article = 123, Title = "test", Label = "Test" }));
        }

        [Fact]
        public void Is_AddNewProduct_have_check_parameter()
        {
            Assert.Throws<ArgumentException>(() => _productService.AddNewProduct(new Product { Article = - 1 }));
            Assert.Throws<ArgumentException>(() =>
                _productService.AddNewProduct(new Product {Article = long.MaxValue}));
            Assert.Throws<ArgumentException>(() =>
                _productService.AddNewProduct(new Product {Article = long.MinValue}));
        }

        [Fact]
        public void Is_GetAllProducts_have_check_for_null()
        {
            Assert.NotNull(_productService.SerializeObject());
            Assert.NotNull(_productService.GetAllProducts().SerializeObject());
        }

        [Fact]
        public void Is_GetAllProducts_return_correct_data()
        {
            Assert.Equal(_productService.GetAllProducts().GetRange(0,4).SerializeObject(),
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
            Assert.Throws<ArgumentException>(() => _productService.GetSizes(default));
            Assert.Throws<ArgumentException>(() => _productService.GetSizes(-1));
            Assert.Throws<ArgumentException>(() => _productService.GetSizes(long.MaxValue));
            Assert.Throws<ArgumentException>(() => _productService.GetSizes(long.MinValue));
            Assert.Equal(_productService.GetSizes(12345).SerializeObject(),
                _productsStub.Products.FirstOrDefault(i => i.Article == 12345).SizesAvailable.SerializeObject());
        }

        [Fact]
        public void Is_GetSizes_return_correct_data()
        {
            Assert.Equal(_productService.GetSizes(12345).SerializeObject(),
                _productsStub.Products.FirstOrDefault(i => i.Article == 12345).SizesAvailable.SerializeObject());
            Assert.NotEqual(_productService.GetSizes(12345).SerializeObject(),
                _productsStub.Products.FirstOrDefault(i => i.Article == 12454).SizesAvailable.SerializeObject());
            for (long i = 1; i < 20000; i++)
                if (i == 12345 || i == 12454)
                    Assert.Equal(_productService.GetSizes(i).SerializeObject(),
                        _productsStub.Products.FirstOrDefault(product => product.Article == i).SizesAvailable
                            .SerializeObject());
                else
                    Assert.Throws<ArgumentException>(() => _productService.GetSizes(i));
        }
    }
}