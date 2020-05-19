using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Shop.Core.Interfaces.DataProviders;
using Shop.Core.Models;
using Shop.Database;

namespace Shop.Tests.Stubs
{
    public class ProductDataProviderStub: IProductDataProvider
    {
        private readonly DatabaseBase _databaseBase;
        private readonly IMemoryCache _cache;
        private const string CacheName = "ProductsList";
        
        public ProductDataProviderStub(IMemoryCache memoryCache)
        {
            _databaseBase = new MainDatabase();
            _cache = memoryCache;
        }
        public List<Product> GetProducts()
        {
            return _databaseBase.GetDatabaseList<Product>().Result;
        }

        public bool AddProductInDatabase(Product product)
        {
            return false;
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