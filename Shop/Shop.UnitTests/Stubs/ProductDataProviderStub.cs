using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Shop.Api.Data.Abstract;
using Shop.Api.Data.Models;
using Shop.Database;

namespace Shop.UnitTests.Stubs
{
    public class ProductDataProviderStub : IProductDataProvider
    {
        private const string CacheName = "ProductsList";
        private readonly IMemoryCache _cache;
        private readonly DatabaseBase _databaseBase;
        private readonly ProductsStub _stub;

        public ProductDataProviderStub(IMemoryCache memoryCache)
        {
            _databaseBase = new MainDatabase();
            _cache = memoryCache;
            _stub = new ProductsStub();
        }

        public List<ProductDto> GetProducts()
        {
            var productList = new List<ProductDto>();
            for (int i = 0; i < 5; i++)
            {
                productList.AddRange(_stub.Products);
            }

            return productList;
        }

        public bool AddProductInDatabase(ProductDto product)
        {
            return true;
        }

        private void SetCache(List<ProductDto> productList, int lifeTime)
        {
            _cache.Set(CacheName, productList, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(lifeTime)
            });
        }
    }
}