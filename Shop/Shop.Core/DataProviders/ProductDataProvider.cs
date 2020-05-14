using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using Shop.Core.Interfaces.DataProviders;
using Shop.Core.Models;
using Shop.Database;
using Shop.Database.Extensions;
using Shop.Database.MongoDB;

namespace Shop.Core.DataProviders
{
    public class ProductDataProvider : IProductDataProvider
    {
        private List<Product> _products;
        private readonly DatabaseBase _databaseBase;
        private readonly IMemoryCache _cache;
        private const string CacheName = "ProductsList";

        public ProductDataProvider(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
            _databaseBase = new MainDatabase();
            _databaseBase = new MongoDatabase(_databaseBase,
                new MongoDatabaseContext(Environment.GetEnvironmentVariable("DB_NAME"), "User"));
        }

        /// <summary>
        /// Function check if db return correct answer
        /// if true - return correct data and cache it
        /// else - return data from fake db
        /// </summary>
        /// <returns>Products list</returns>
        public List<Product> GetProducts()
        {
            try
            {
                // if (!_cache.TryGetValue(CacheName, out _products))
                // {
                //     _products = _databaseBase.GetDatabaseList<Product>().Result;
                //     if (_products.IsNullOrEmpty() || _products.Any(i => i.Article == 0))
                //     {
                //         throw new NullReferenceException();
                //     }
                //     SetCache(_products, 1);
                // }
                _products = _databaseBase.GetDatabaseList<Product>().Result;
                return _products;
            }
            catch (Exception)
            {
                return new MainDatabase().GetDatabaseList<Product>().Result;
            }
        }

        public void AddProductInDatabase(Product product)
        {
            _databaseBase.AddInDatabase(product);
            if (_cache.TryGetValue(CacheName, out _products) && !_products.Contains(product))
            {
                SetCache(_products, 1);
            }
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