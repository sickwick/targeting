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
            _databaseBase = new MongoDatabase(new MainDatabase(),
                new MongoDatabaseContext(Environment.GetEnvironmentVariable("DB_NAME"), "User"));
        }

        /// <summary>
        /// Function try get data from db,
        /// if request isn't the first, return data from cache
        /// else do new request to db and return them
        /// </summary>
        /// <returns>Products list</returns>
        public List<Product> GetProducts()
        {
            if (!_cache.TryGetValue(CacheName, out _products))
            {
                _products = _databaseBase.GetDatabaseList<Product>().Result;
                if (_products.IsNullOrEmpty() || _products.Any(i => i.Article == 0))
                {
                    throw new NullReferenceException();
                }
                SetCache(_products, 1);
            }
                
            return _products;
        }
        
        /// <summary>
        /// Function add new item in list and try to update cache
        /// </summary>
        /// <param name="product"></param>
        public bool AddProductInDatabase(Product product)
        {
            if (_products.IsNullOrEmpty())
            {
                GetProducts();
            }
            else
            {
                if (!_products.Contains(product))
                {
                    _databaseBase.AddInDatabase(product);
                    _products.Add(product);
                    SetCache(_products, 1);
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            return _cache.TryGetValue(CacheName, out List<Product> newCache) && newCache.SequenceEqual(_products);
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