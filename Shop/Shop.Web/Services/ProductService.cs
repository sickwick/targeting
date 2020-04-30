using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Database;
using Shop.Database.MongoDB;
using Shop.Web.Interfaces;
using Shop.Web.Models;

namespace Shop.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly DatabaseBase _databaseBase;
        private readonly MongoDatabase _mongoDatabase;

        public ProductService(DatabaseBase databaseBase)
        {
            _databaseBase = databaseBase;
            _mongoDatabase = new MongoDatabase(_databaseBase,
                new MongoDatabaseContext(Environment.GetEnvironmentVariable("DB_NAME"), "User"));
        }

        public List<Product> GetAllProducts()
        {
            try
            {
                var result = _databaseBase.GetDatabaseList<Product>().Result ?? throw new NullReferenceException();
                return result;
            }
            catch
            {
                return new MainDatabase().GetDatabaseList<Product>().Result;
            }
        }

        public Product GetProduct(long article)
        {
            if (article <= 0 || article == default)
            {
                return new Product();
            }
            try
            {
                var result = _databaseBase.GetDatabaseList<Product>().Result.FirstOrDefault(i => i.Article == article);
                return result.Article != default ? result : throw new NullReferenceException();
            }
            catch
            {
                return new MainDatabase().GetDatabaseList<Product>().Result.FirstOrDefault(i => i.Article == article);
            }
        }

        public List<Sizes> GetSizes(long article)
        {
            return GetProduct(article).SizesAvailable.ToList();
        }

        public bool AddNewProduct(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}