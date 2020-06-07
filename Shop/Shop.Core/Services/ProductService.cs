using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Core.ListHolders;
using Shop.Storage.Extensions;
using Shop.Storage.Interfaces.DataProviders;
using Shop.Storage.Interfaces.Services;
using Shop.Storage.Models;

namespace Shop.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDataProvider _productDataProvider;
        private readonly List<Product> _products;

        public ProductService(IProductDataProvider productDataProvider)
        {
            _productDataProvider = productDataProvider;
            _products = ProductListHolder.GetInstance().ProductList;
        }

        public List<Product> GetAllProducts()
        {
            if (!_products.IsNullOrEmpty())
            {
                return _products;
            }

            throw new NullReferenceException();
        }

        public Product GetProduct(long article)
        {
            if (CheckParameterIncorrect(article) && _products.Any(p => p.Article == article))
                return _products.FirstOrDefault(p => p.Article == article);

            throw new ArgumentException();
        }

        public List<Sizes> GetSizes(long article)
        {
            if (CheckParameterIncorrect(article)) return GetProduct(article).SizesAvailable.ToList();

            throw new ArgumentNullException();
        }

        public bool AddNewProduct(Product product)
        {
            if (!CheckParameterIncorrect(product)) return _productDataProvider.AddProductInDatabase(product);

            throw new ArgumentNullException();
        }

        private bool CheckParameterIncorrect(long param)
        {
            return param > 0 && param != default && param < long.MaxValue;
        }

        /// <summary>
        /// </summary>
        /// <param name="product"></param>
        /// <returns>True - when you has WRONG product argument, else false </returns>
        private bool CheckParameterIncorrect(Product product)
        {
            return string.IsNullOrEmpty(product.Title) &&
                   string.IsNullOrEmpty(product.Label) && CheckParameterIncorrect(product.Article);
        }
    }
}