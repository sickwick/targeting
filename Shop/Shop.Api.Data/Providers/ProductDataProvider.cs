using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using Shop.Api.Data.Abstract;
using Shop.Api.Data.ListHolders;
using Shop.Api.Data.Models;
using Shop.Database;
using Shop.Database.MongoDB;

namespace Shop.Api.Data.Providers
{
    public class ProductDataProvider : IProductDataProvider
    {
        private const string CacheName = "ProductsList";
        private readonly IMemoryCache _cache;
        private readonly DatabaseBase _databaseBase;
        private List<ProductDto> _products;

        public ProductDataProvider(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
            _databaseBase = new MongoDatabase(new MainDatabase(),
                new MongoDatabaseContext(Environment.GetEnvironmentVariable("DB_NAME"), "Shop"));
        }

        /// <summary>
        ///     Function try get data from db,
        ///     if request isn't the first, return data from cache
        ///     else do new request to db and return them
        /// </summary>
        /// <returns>Products list</returns>
        public List<ProductDto> GetProducts()
        {
            if (_cache.TryGetValue(CacheName, out _products))
            { 
                return ProductListHolder.GetInstance().ProductList;
            }

            _products = _databaseBase.GetDatabaseList<ProductDto>().Result;
            if (_products.IsNullOrEmpty() || _products.Any(i => i.Article == 0)) {
                SetCache(_products, 1);
            }
            else
            {
                throw new NullReferenceException();
            }

            return _products;
        }

        /// <summary>
        ///     Function add new item in list and try to update cache
        /// </summary>
        /// <param name="product"></param>
        public bool AddProductInDatabase(ProductDto product)
        {
            if (_products.IsNullOrEmpty()) _products = GetProducts();

            if (!_products.Contains(product))
            {
                _databaseBase.AddInDatabase(product);
                _products.Add(product);
                SetCache(_products, 1);
                ProductListHolder.GetInstance().UpdateProductList();
            }
            else
            {
                throw new ArgumentException();
            }

            return _cache.TryGetValue(CacheName, out List<ProductDto> newCache) && newCache.SequenceEqual(_products);
        }

        private void SetCache(List<ProductDto> productList, int lifeTime)
        {
            _cache.Set(CacheName, productList, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(lifeTime)
            });
        }
    }
}