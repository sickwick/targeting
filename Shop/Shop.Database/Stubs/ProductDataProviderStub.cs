using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Shop.Storage.Interfaces.DataProviders;
using Shop.Storage.Models;

namespace Shop.Database.Stubs
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

        public List<Product> GetProducts()
        {
            var productList = new List<Product>();
            for (int i = 0; i < 5; i++)
            {
                productList.AddRange(_stub.Products);
            }

            return productList;
        }

        public bool AddProductInDatabase(Product product)
        {
            return true;
        }

        private void SetCache(List<Product> productList, int lifeTime)
        {
            _cache.Set(CacheName, productList, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(lifeTime)
            });
        }
    }
}