using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Microsoft.Extensions.DependencyInjection;
using Shop.Core.DataProviders;
using Shop.Storage.Interfaces.DataProviders;
using Shop.Storage.Models;

namespace Shop.Core.ListHolders
{
    public sealed class ProductListHolder
    {
        private static readonly Lazy<ProductListHolder> _singleInstance =
            new Lazy<ProductListHolder>(()=>new ProductListHolder());

        internal List<Product> ProductList;
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

        public List<Product> GetProductList()
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