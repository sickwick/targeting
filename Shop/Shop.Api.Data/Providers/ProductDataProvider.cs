using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Api.Data.Abstract;
using Shop.Api.Data.Models;
using Shop.Database;
using Shop.Database.MongoDB;

namespace Shop.Api.Data.Providers
{
    public class ProductDataProvider : IProductDataProvider
    {
        private readonly DatabaseBase _databaseBase;
        private List<ProductDto> _products;

        public ProductDataProvider()
        {
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
            _products = _databaseBase.GetDatabaseList<ProductDto>().Result;
            
            if (_products.IsNullOrEmpty() || _products.Any(i => i.Article == 0)) {
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
            // if (_products.IsNullOrEmpty()) _products = GetProducts();
            //
            // if (!_products.Contains(product))
            // {
            //     _databaseBase.AddInDatabase(product);
            //     _products.Add(product);
            //     SetCache(_products, 1);
            //     ProductListHolder.GetInstance().UpdateProductList();
            // }
            // else
            // {
            //     throw new ArgumentException();
            // }
        
            throw new NotImplementedException();
        }
    }
}