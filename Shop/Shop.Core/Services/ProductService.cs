using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Shop.Core.Interfaces.DataProviders;
using Shop.Core.ListHolders;
using Shop.Core.Models;
using Shop.Database.Extensions;
using Shop.WebAPI.Interfaces;

namespace Shop.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDataProvider _productDataProvider;
        private readonly List<Product> Products;

        public ProductService(IProductDataProvider productDataProvider, IServiceProvider container)
        {
            _productDataProvider = productDataProvider;
            Products = ProductListHolder.GetInstance(container).ProductList;
        }

        public List<Product> GetAllProducts()
        {
            if (!_productDataProvider.GetProducts().IsNullOrEmpty())
            {
                return _productDataProvider.GetProducts();
            }
            
            throw new NullReferenceException();
        }

        public Product GetProduct(long article)
        {
            if (CheckParameter(article) && _productDataProvider.GetProducts().Any(p=>p.Article == article))
            {
                return _productDataProvider.GetProducts().FirstOrDefault(p => p.Article == article);
            }
            
            throw new ArgumentException();
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
            // if (CheckParameter(product))
            // {
            //     try
            //     {
            //         if (_mongoDatabase.GetDatabaseList<Product>().Result.All(p => p.Article != product.Article))
            //         {
            //             _mongoDatabase.AddInDatabase(product);
            //             return _mongoDatabase.GetDatabaseList<Product>().Result.Any(p => p.Article == product.Article);
            //         }
            //         
            //         throw new InvalidEnumArgumentException();
            //     }
            //     catch
            //     {
            //         var db = new MainDatabase();
            //         db.AddInDatabase(product);
            //         return db.GetDatabaseList<Product>().Result.Any(p=>p.Article == product.Article);
            // }
        // }
            
            throw new NotImplementedException();
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