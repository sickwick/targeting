using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Core.Interfaces.DataProviders;
using Shop.Core.Interfaces.Services;
using Shop.Core.ListHolders;
using Shop.Core.Models;
using Shop.Database.Extensions;

namespace Shop.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDataProvider _productDataProvider;
        private readonly List<Product> Products;

        public ProductService(IProductDataProvider productDataProvider)
        {
            _productDataProvider = productDataProvider;
            Products = ProductListHolder.GetInstance().ProductList;
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
            if (CheckParameterIncorrect(article) && _productDataProvider.GetProducts().Any(p => p.Article == article))
            {
                return _productDataProvider.GetProducts().FirstOrDefault(p => p.Article == article);
            }

            throw new ArgumentException();
        }

        public Sizes GetSizes(long article)
        {
            if (CheckParameterIncorrect(article))
            {
                return GetProduct(article).SizesAvailable;
            }

            throw new ArgumentNullException();
        }

        public bool AddNewProduct(Product product)
        {
            if (!CheckParameterIncorrect(product))
            {
                return _productDataProvider.AddProductInDatabase(product);
            }
            
            throw new ArgumentException();
        }

        private bool CheckParameterIncorrect(long param)
        {
            return param > 0 && param != default && param < long.MaxValue;
        }

        /// <summary>
        /// 
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