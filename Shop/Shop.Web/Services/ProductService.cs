using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            if (CheckParameter(article))
            {
                try
                { 
                    var result = _databaseBase.GetDatabaseList<Product>().Result.FirstOrDefault(i => i.Article == article);
                    return result.Article != default ? result : throw new NullReferenceException();
                }
                catch
                {
                    var products = new MainDatabase().GetDatabaseList<Product>().Result;
                    if (products.Any(i => i.Article == article))
                    {
                        return products.FirstOrDefault(product => product.Article == article);
                    }
                    
                    throw new ArgumentException();
                }   
            }
            
            throw new ArgumentNullException();
        }

        public List<Sizes> GetSizes(long article)
        {
            if (CheckParameter(article))
            {
                return GetProduct(article).SizesAvailable.ToList();
            }

            throw new ArgumentNullException();
        }

        public bool AddNewProduct(Product product)
        {
            if (CheckParameter(product))
            {
                try
                {
                    if (_mongoDatabase.GetDatabaseList<Product>().Result.All(p => p.Article != product.Article))
                    {
                        _mongoDatabase.AddInDatabase(product);
                        return _mongoDatabase.GetDatabaseList<Product>().Result.Any(p => p.Article == product.Article);
                    }
                    
                    throw new InvalidEnumArgumentException();
                }
                catch
                {
                    var db = new MainDatabase();
                    db.AddInDatabase(product);
                    return db.GetDatabaseList<Product>().Result.Any(p=>p.Article == product.Article);
                }
            }
            
            throw new ArgumentNullException();
        }

        private bool CheckParameter(long param)
        {
            return param > 0 && param != default && param < long.MaxValue;
        }

        private bool CheckParameter(Product product)
        {
            return string.IsNullOrEmpty(product.Title) && product.SizesAvailable.IsNullOrEmpty() &&
                   string.IsNullOrEmpty(product.Label) && CheckParameter(product.Article);
        }
    }
}