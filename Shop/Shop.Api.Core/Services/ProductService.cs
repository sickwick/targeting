using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Shop.Api.Core.Abstract;
using Shop.Api.Core.Models;
using Shop.Api.Data;
using Shop.Api.Data.Abstract;
using Shop.Api.Data.Models;

namespace Shop.Api.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDataProvider _productDataProvider;
        private readonly IMapper _mapper;

        public ProductService(IProductDataProvider productDataProvider, IMapper mapper)
        {
            _productDataProvider = productDataProvider;
            _mapper = mapper;
        }

        public List<Product> GetAllProducts()
        {
            var products = _productDataProvider.GetProducts();
            if (!products.IsNullOrEmpty())
            {
                var result = new List<Product>();
                foreach (var product in products)
                {
                    result.Add(_mapper.Map<ProductDto, Product>(product));
                }
                return result;
            }

            throw new NullReferenceException();
        }

        public Product GetProduct(long article)
        {
            var products = _productDataProvider.GetProducts();
            if (CheckParameterCorrect(article) && products.Any(p => p.Article == article))
            {
                var product =  products.FirstOrDefault(p => p.Article == article);
                return _mapper.Map<ProductDto,Product>(product);
            }

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
                return _productDataProvider.AddProductInDatabase(_mapper.Map<ProductDto>(product));
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