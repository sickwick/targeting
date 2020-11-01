using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Shop.Api.Core;
using Shop.Api.Core.Models;
using Shop.Api.Data.Abstract;
using Shop.Api.Data.Models;

namespace Shop.Api.Data.ListHolders
{
    public sealed class ProductListHolder
    {
        private static readonly Lazy<ProductListHolder> _singleInstance =
            new Lazy<ProductListHolder>(() => new ProductListHolder());

        internal List<ProductDTO> ProductList;
        private IProductDataProvider _productDataProvider;

        private ProductListHolder()
        {
            _productDataProvider = ContainerConfig.ServiceProvider.GetService<IProductDataProvider>();
            ProductList = GetProductList();
        }

        static ProductListHolder()
        {
            if (_singleInstance == null)
            {
                _singleInstance = new Lazy<ProductListHolder>();
            }
        }

        public List<ProductDTO> GetProductList()
        {
            return _productDataProvider.GetProducts();
        }
        
        public void UpdateProductList()
        {
            ProductList = GetProductList();
        }
        
        public static ProductListHolder GetInstance()
        {
            return _singleInstance.Value;
        }
    }
}