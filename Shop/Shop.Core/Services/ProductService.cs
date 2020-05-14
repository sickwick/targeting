using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
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
            if (CheckParameter(article) && _productDataProvider.GetProducts().Any(p => p.Article == article))
            {
                return _productDataProvider.GetProducts().FirstOrDefault(p => p.Article == article);
            }

            throw new ArgumentException();
        }

        public Sizes GetSizes(long article)
        {
            if (CheckParameter(article))
            {
                return GetProduct(article).SizesAvailable;
            }

            throw new ArgumentNullException();
        }

        public bool AddNewProduct(Product product)
        {
            if (CheckParameter(product))
            {
                _productDataProvider.AddProductInDatabase(product);
                if (Products.Contains(product))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckParameter(long param)
        {
            return param > 0 && param != default && param < long.MaxValue;
        }

        private bool CheckParameter(Product product)
        {
            return string.IsNullOrEmpty(product.Title) &&
                   string.IsNullOrEmpty(product.Label) && CheckParameter(product.Article);
        }
    }
}