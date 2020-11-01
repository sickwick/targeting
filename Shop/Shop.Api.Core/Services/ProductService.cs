using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Api.Core.Abstract;
using Shop.Api.Core.Models;
using Shop.Api.Data.Abstract;

namespace Shop.Api.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDataProvider _productDataProvider;
        private readonly List<Product> _products;

        public ProductService(IProductDataProvider productDataProvider)
        {
            _productDataProvider = productDataProvider;
            _products = _productDataProvider?.GetProducts();
        }

        public List<Product> GetAllProducts()
        {
            if (!_products.IsNullOrEmpty())
            {
                return _productDataProvider.GetProducts();
            }

            throw new NullReferenceException();
        }

        public Product GetProduct(long article)
        {
            if (CheckParameterCorrect(article) && _products.Any(p => p.Article == article))
                return _products.FirstOrDefault(p => p.Article == article);

            throw new ArgumentException("�������� �� ������ ��������", nameof(article));
        }

        public List<Sizes> GetSizes(long article)
        {
            if (CheckParameterCorrect(article)) return GetProduct(article).SizesAvailable.ToList();

            throw new ArgumentException("�������� �� ������ ��������", nameof(article));
        }

        public bool AddNewProduct(Product product)
        {
            if (CheckParameterCorrect(product))
            {
                return _productDataProvider.AddProductInDatabase(product);
            }

            throw new ArgumentException("�������� �� ������ ��������", nameof(product));
        }

        private bool CheckParameterCorrect(long param)
        {
            return param > 0 && param != default && param < long.MaxValue;
        }

        /// <summary>
        /// </summary>
        /// <param name="product"></param>
        /// <returns>True - when you has WRONG product argument, else false </returns>
        private bool CheckParameterCorrect(Product product)
        {
            return !string.IsNullOrEmpty(product.Title) &&
                   !string.IsNullOrEmpty(product.Label) && CheckParameterCorrect(product.Article);
        }
    }
}