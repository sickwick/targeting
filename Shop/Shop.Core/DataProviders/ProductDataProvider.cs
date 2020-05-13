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

        public ProductDataProvider(IMemoryCache memoryCache)
        {
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
                const string cacheName = "ProductsList";
                if (!_cache.TryGetValue(cacheName, out _products))
                {
                    _products = _databaseBase.GetDatabaseList<Product>().Result;
                    if (!_products.IsNullOrEmpty() && _products.All(i => i.Article != 0))
                    {
                        _cache.Set(cacheName, _products, new MemoryCacheEntryOptions
                        {
                            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(2)
                        });
                    }

                    return _products;
                }

                throw new NullReferenceException();
            }
            catch (Exception)
            {
                return new MainDatabase().GetDatabaseList<Product>().Result;
            }
        }
    }
}